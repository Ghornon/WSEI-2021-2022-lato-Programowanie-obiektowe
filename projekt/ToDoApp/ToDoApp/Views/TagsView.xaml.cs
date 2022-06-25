using System;
using System.Linq;
using System.Windows;
using ToDoApp.Helpers;
using ToDoApp.Models;

namespace ToDoApp.Views
{
    /// <summary>
    /// Interaction logic for TagsView.xaml
    /// </summary>
    public partial class TagsView : Window
    {
        private AppDBContext context;
        private AuthHelper authHelper { get; }

        public delegate void IssueCloseDelegate(object sender, EventArgs e);
        public event IssueCloseDelegate IssueClose;
        public TagsView(AuthHelper authHelper)
        {
            this.authHelper = authHelper;

            InitializeComponent();

            this.RefreshData();
        }
        private void RefreshData()
        {
            using (context = new AppDBContext())
            {
                var query = from tag in context.Tags
                            where tag.UserId == this.authHelper.User.Id
                            select tag.Name;

                if (query == null)
                    return;

                TagsList.ItemsSource = query.ToList();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (IssueClose != null)
                IssueClose(this, EventArgs.Empty);

            this.Owner.Show();
        }

        private void TagCreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TagName.Text == null)
            {
                MessageBox.Show("Enter tag name!");
                return;
            }

            using (context = new AppDBContext())
            {
                var tag = context.Tags.Where(tag => tag.Name == TagName.Text && tag.UserId == this.authHelper.User.Id).FirstOrDefault();

                if (tag != null)
                {
                    MessageBox.Show("Tag already exist");
                    return;
                }

                var newTag = new Tag
                {
                    Name = TagName.Text,
                    UserId = this.authHelper.User.Id
                };

                context.Tags.Add(newTag);
                context.SaveChanges();
            }

            this.RefreshData();
        }

        private void TagUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TagsList.SelectedItem == null)
            {
                MessageBox.Show("Point to tag to update!");
                return;
            }

            using (context = new AppDBContext())
            {
                var tag = context.Tags.Where(tag => tag.Name == TagsList.SelectedItem.ToString() && tag.UserId == this.authHelper.User.Id).FirstOrDefault();

                tag.Name = TagName.Text;

                context.Tags.Update(tag);

                context.SaveChanges();
            }

            this.RefreshData();
        }

        private void TagDeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TagsList.SelectedItem == null)
            {
                MessageBox.Show("Point to tag to delete!");
                return;
            }

            using (context = new AppDBContext())
            {
                var tag = context.Tags.Where(tag => tag.Name == TagsList.SelectedItem.ToString() && tag.UserId == this.authHelper.User.Id).FirstOrDefault();
                var taggedTasks = from taggedTask in context.TaggedTasks where taggedTask.TagId == tag.Id select taggedTask;

                foreach (var t in taggedTasks)
                    context.TaggedTasks.Remove(t);

                context.Tags.Remove(tag);

                context.SaveChanges();
            }

            this.RefreshData();
        }

        private void TagsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TagsList.SelectedItem == null)
                return;

            TagName.Text = TagsList.SelectedItem.ToString();
        }
        protected override void OnClosed(EventArgs e)
        {
            if (IssueClose != null)
                IssueClose(this, EventArgs.Empty);

            this.Owner.Show();
        }
    }
}