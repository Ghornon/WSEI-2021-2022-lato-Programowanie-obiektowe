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
        /// <summary>The context</summary>
        private AppDBContext context;

        /// <summary>Gets the authentication helper.</summary>
        /// <value>The authentication helper.</value>
        private AuthHelper authHelper { get; }

        /// <summary>
        ///   Issue onClose event
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        public delegate void IssueCloseDelegate(object sender, EventArgs e);

        public event IssueCloseDelegate IssueClose;

        /// <summary>Initializes a new instance of the <see cref="TagsView" /> class.</summary>
        /// <param name="authHelper">The authentication helper.</param>
        public TagsView(AuthHelper authHelper)
        {
            this.authHelper = authHelper;

            InitializeComponent();

            this.RefreshData();
        }

        /// <summary>Refreshes the data.</summary>
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

        /// <summary>Handles the Click event of the CancelButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (IssueClose != null)
                IssueClose(this, EventArgs.Empty);

            this.Owner.Show();
        }

        /// <summary>Handles the Click event of the TagCreateButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
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

        /// <summary>Handles the Click event of the TagUpdateButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
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

        /// <summary>Handles the Click event of the TagDeleteButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
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

        /// <summary>Handles the SelectionChanged event of the TagsList control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void TagsList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TagsList.SelectedItem == null)
                return;

            TagName.Text = TagsList.SelectedItem.ToString();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Window.Closed">Closed</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnClosed(EventArgs e)
        {
            if (IssueClose != null)
                IssueClose(this, EventArgs.Empty);

            this.Owner.Show();
        }
    }
}