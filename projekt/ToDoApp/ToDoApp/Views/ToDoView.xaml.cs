using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDoApp.Helpers;
using ToDoApp.Models;

namespace ToDoApp.Views
{
    /// <summary>
    /// Interaction logic for ToDoView.xaml
    /// </summary>
    public partial class ToDoView : Window
    {
        /// <summary>The context</summary>
        private AppDBContext context;
        /// <summary>Gets the authentication helper.</summary>
        /// <value>The authentication helper.</value>
        private AuthHelper authHelper { get; }

        /// <summary>Initializes a new instance of the <see cref="ToDoView" /> class.</summary>
        /// <param name="authHelper">The authentication helper.</param>
        public ToDoView(AuthHelper authHelper)
        {
            this.authHelper = authHelper;

            if (!this.authHelper.IsAuthenticated)
                return;

            InitializeComponent();

            using (context = new AppDBContext())
            {
                var statuses = context.Statuses.ToList();
                foreach (Status status in statuses)
                {
                    TaskStatus.Items.Add(status);
                }
            }

            this.RefreshData();
        }

        /// <summary>Refreshes the data.</summary>
        private void RefreshData()
        {
            using (context = new AppDBContext())
            {
                var queryTasks = from task in context.Tasks
                                 where task.UserId == authHelper.User.Id
                                 orderby task.Date
                                 select new TasksListView(task.Id, task.Name, task.Status.Name, task.Date);

                TasksList.ItemsSource = queryTasks.ToList();

                var tagsQuery = from tag in context.Tags
                                where tag.UserId == this.authHelper.User.Id
                                select tag.Name;

                if (tagsQuery == null)
                    return;

                TaskTags.ItemsSource = tagsQuery.ToList();
            }
        }

        /// <summary>Handles the Click event of the SignOutButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        /// <summary>Handles the Click event of the TaskCreateButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void TaskCreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskName.Text == null || TaskStatus.SelectedItem == null)
            {
                MessageBox.Show("Please make sure all data has been entered!");
                return;
            }

            using (context = new AppDBContext())
            {
                var newTask = new Models.Task
                {
                    Name = TaskName.Text,
                    StatusId = (TaskStatus.SelectedItem as Status).Id,
                    Date = TaskDate.SelectedDate,
                    UserId = this.authHelper.User.Id
                };
                context.Tasks.Add(newTask);
                context.SaveChanges();

                foreach (var t in TaskTags.SelectedItems)
                {
                    var tag = context.Tags.Where(tag => tag.Name == t.ToString() && tag.UserId == this.authHelper.User.Id).FirstOrDefault();
                    var taggedtask = context.TaggedTasks.Where(tagged => tagged.TaskId == newTask.Id && tagged.TagId == tag.Id).FirstOrDefault();

                    if (taggedtask != null)
                    {
                        return;
                    }

                    var newTaggedTask = new TaggedTask
                    {
                        TagId = tag.Id,
                        TaskId = newTask.Id
                    };

                    context.TaggedTasks.Add(newTaggedTask);
                    context.SaveChanges();
                }
            }

            this.RefreshData();
        }

        /// <summary>Handles the Click event of the TaskDeleteButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void TaskDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedItem == null)
            {
                MessageBox.Show("Please select any record!");
                return;
            }

            using (context = new AppDBContext())
            {
                var selectedItem = (TasksListView)TasksList.SelectedItem;

                var task = context.Tasks.Find(selectedItem.Id);

                var taggedTasks = from taggedTask in context.TaggedTasks where taggedTask.TaskId == task.Id select taggedTask;

                foreach (var t in taggedTasks)
                    context.TaggedTasks.Remove(t);

                context.Tasks.Remove(task);
                context.SaveChanges();
            }

            this.RefreshData();
        }

        /// <summary>Handles the Click event of the TaskUpdateButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void TaskUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksList.SelectedItem == null)
            {
                MessageBox.Show("Please select any record!");
                return;
            }

            using (context = new AppDBContext())
            {
                var selectedItem = (TasksListView)TasksList.SelectedItem;

                var task = context.Tasks.Find(selectedItem.Id);

                task.Name = TaskName.Text;
                task.StatusId = (TaskStatus.SelectedItem as Status).Id;
                task.Date = TaskDate.SelectedDate;
                task.UserId = this.authHelper.User.Id;

                foreach (var t in TaskTags.SelectedItems)
                {
                    foreach (var t2 in TaskTags.Items)
                    {
                        if (t != t2)
                        {
                            var currentTag = context.Tags.Where(tag => tag.Name == t2.ToString() && tag.UserId == this.authHelper.User.Id).FirstOrDefault();
                            var taggedTask = context.TaggedTasks.Where(tagged => tagged.TaskId == task.Id && tagged.TagId == currentTag.Id).FirstOrDefault();

                            if (taggedTask != null)
                            {
                                context.TaggedTasks.Remove(taggedTask);
                            }
                        }
                    }

                    var tag = context.Tags.Where(tag => tag.Name == t.ToString() && tag.UserId == this.authHelper.User.Id).FirstOrDefault();
                    var taggedtask = context.TaggedTasks.Where(tagged => tagged.TaskId == task.Id && tagged.TagId == tag.Id).FirstOrDefault();

                    if (taggedtask == null)
                    {
                        var newTaggedTask = new TaggedTask
                        {
                            TagId = tag.Id,
                            TaskId = task.Id
                        };

                        context.TaggedTasks.Add(newTaggedTask);
                    }
                }

                context.Tasks.Update(task);
                context.SaveChanges();
            }

            this.RefreshData();
        }

        /// <summary>Handles the SelectionChanged event of the TasksList control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void TasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksList.SelectedItem == null)
                return;

            var selectedItem = (TasksListView)TasksList.SelectedItem;
            TaskName.Text = selectedItem.Name;
            TaskDate.SelectedDate = selectedItem.Date;

            using (context = new AppDBContext())
            {
                var task = context.Tasks.Find(selectedItem.Id);
                var newStatus = context.Statuses.Find(task.StatusId).Id - 1;
                TaskStatus.SelectedIndex = newStatus;

                var queryTagsName = from tagged in context.TaggedTasks
                                    join tags in context.Tags on tagged.TagId equals tags.Id
                                    where tagged.TaskId == task.Id
                                    select tags.Name;

                TaskTags.SelectedItem = null;

                foreach (var t in queryTagsName)
                    TaskTags.SelectedItems.Add(t);
            }
        }

        /// <summary>Handles the Click event of the ManageTagsButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ManageTagsButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new TagsView(this.authHelper);

            window.Owner = this;
            window.IssueClose += NewWindow_IssueClose;
            this.Hide();
            window.ShowDialog();
        }
        /// <summary>Raises the <see cref="E:System.Windows.Window.Closed">Closed</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            this.Owner.Show();
            base.OnClosed(e);
        }

        /// <summary>Creates new window_issueclose.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void NewWindow_IssueClose(object sender, EventArgs e)
        {
            this.RefreshData();
            var closedWindow = (TagsView)sender;
            closedWindow.Close();
        }
    }

    /// <summary>
    ///   Generate output for a data grid
    ///   Generate output for a data grid
    /// </summary>
    public class TasksListView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StatusName { get; set; }
        public string Tags { get; set; }
        public DateTime? Date { get; set; }

        /// <summary>Initializes a new instance of the <see cref="TasksListView" /> class.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="statusName">Name of the status.</param>
        /// <param name="date">The date.</param>
        public TasksListView(int id, string name, string statusName, DateTime? date)
        {
            this.Id = id;
            this.Name = name;
            this.StatusName = statusName;
            this.Tags = this.GetTagsString(id);
            this.Date = date;
        }

        /// <summary>Gets the tags in string format.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   Tags in string separated by comma
        /// </returns>
        private string GetTagsString(int id)
        {
            var tagsString = "";
            using (var context = new AppDBContext())
            {
                var query = from tagged in context.TaggedTasks
                            join tags in context.Tags on tagged.TagId equals tags.Id
                            where tagged.TaskId == id
                            select tags.Name;

                foreach (string s in query.ToArray())
                    tagsString += ", " + s;

                if (tagsString.Length != 0)
                    tagsString = tagsString.Remove(0, 2);
            }

            return tagsString;
        }
    }
}