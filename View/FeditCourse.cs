using System;
using System.Windows.Forms;
using LibLapin;

namespace Utdl.View {
    public partial class FeditCourse:Form {
        State state;
        ListBox.ObjectCollection items;
        int position;

        public FeditCourse(State state, ListBox.ObjectCollection items, int position)
        {
            InitializeComponent();
            btnValider.Click += this.btnValider_Click;
            this.state = state;
            this.items = items;
            this.position = position;
            switch (state)
            {
                case State.added:
                    this.Text = "Création d'une course";
                    break;
                case State.modified:
                    Course course = (Course)items[position];
                    this.tbId.Text = course.Id.ToString();
                    this.tbDistance.Text = course.Distance.ToString();
                    this.Text = "Modification d'une course";
                    break;
                case State.deleted:
                    this.Text = "Suppression d'une course";
                    break;
                case State.unChanged:
                    this.Text = "Consultation d'une course";
                    break;
                default:
                    break;
            }
        }


        private void btnValider_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case State.added:
                    items.Add(new Course(0, Convert.ToInt32(this.tbDistance.Text), this.state));
                    break;
                case State.modified:
                    Course course = (Course)items[position];
                    course.Distance = Convert.ToInt32(this.tbDistance.Text);
                    course.State = this.state;
                    items[this.position] = course;
                    break;
                case State.deleted:
                    break;
                case State.unChanged:
                    break;
                default:
                    break;
            }
            this.Close();
        }
    }
}