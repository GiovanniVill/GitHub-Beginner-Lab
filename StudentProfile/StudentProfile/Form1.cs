using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StudentProfile
{
    public partial class Form1 : Form
    {
        private TextBox txtStudentId;
        private Button btnSearch;
        private Label lblStudentId;
        private Label lblName;
        private Label lblCourse;
        private Label lblYearLevel;

        private Dictionary<string, Student> students;

        public Form1()
        {
            InitializeComponent();

            students = new Dictionary<string, Student>
            {
                { "1001", new Student("1001", "Juan Dela Cruz", "BS Information Technology", "3") },
                { "1002", new Student("1002", "Maria Santos", "BS Computer Science", "2") },
                { "1003", new Student("1003", "Pedro Reyes", "BS Information Technology", "4") }
            };

            CreateStudentProfileUI();
        }

        private void CreateStudentProfileUI()
        {
            this.Text = "Student Profile";
            this.Width = 500;
            this.Height = 400;

            Label title = new Label();
            title.Text = "Student Profile";
            title.Font = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new System.Drawing.Point(150, 30);
            this.Controls.Add(title);

            Label searchLabel = new Label();
            searchLabel.Text = "Enter Student ID:";
            searchLabel.AutoSize = true;
            searchLabel.Location = new System.Drawing.Point(50, 90);
            this.Controls.Add(searchLabel);

            txtStudentId = new TextBox();
            txtStudentId.Location = new System.Drawing.Point(180, 87);
            txtStudentId.Width = 150;
            this.Controls.Add(txtStudentId);

            btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new System.Drawing.Point(340, 85);
            btnSearch.Click += BtnSearch_Click;
            this.Controls.Add(btnSearch);

            Label studentIdTitle = new Label();
            studentIdTitle.Text = "Student ID:";
            studentIdTitle.AutoSize = true;
            studentIdTitle.Location = new System.Drawing.Point(50, 140);
            this.Controls.Add(studentIdTitle);

            lblStudentId = new Label();
            lblStudentId.Text = "-";
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new System.Drawing.Point(180, 140);
            this.Controls.Add(lblStudentId);

            Label nameTitle = new Label();
            nameTitle.Text = "Name:";
            nameTitle.AutoSize = true;
            nameTitle.Location = new System.Drawing.Point(50, 175);
            this.Controls.Add(nameTitle);

            lblName = new Label();
            lblName.Text = "-";
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(180, 175);
            this.Controls.Add(lblName);

            Label courseTitle = new Label();
            courseTitle.Text = "Course:";
            courseTitle.AutoSize = true;
            courseTitle.Location = new System.Drawing.Point(50, 210);
            this.Controls.Add(courseTitle);

            lblCourse = new Label();
            lblCourse.Text = "-";
            lblCourse.AutoSize = true;
            lblCourse.Location = new System.Drawing.Point(180, 210);
            this.Controls.Add(lblCourse);

            Label yearTitle = new Label();
            yearTitle.Text = "Year Level:";
            yearTitle.AutoSize = true;
            yearTitle.Location = new System.Drawing.Point(50, 245);
            this.Controls.Add(yearTitle);

            lblYearLevel = new Label();
            lblYearLevel.Text = "-";
            lblYearLevel.AutoSize = true;
            lblYearLevel.Location = new System.Drawing.Point(180, 245);
            this.Controls.Add(lblYearLevel);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string studentId = txtStudentId.Text.Trim();

            if (students.ContainsKey(studentId))
            {
                Student student = students[studentId];

                lblStudentId.Text = student.StudentId;
                lblName.Text = student.Name;
                lblCourse.Text = student.Course;
                lblYearLevel.Text = student.YearLevel;
            }
            else
            {
                MessageBox.Show(
                    "No student was found with Student ID: " + studentId,
                    "Student Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblStudentId.Text = "-";
                lblName.Text = "-";
                lblCourse.Text = "-";
                lblYearLevel.Text = "-";
            }
        }
    }

    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Course { get; set; }
        public string YearLevel { get; set; }

        public Student(string studentId, string name, string course, string yearLevel)
        {
            StudentId = studentId;
            Name = name;
            Course = course;
            YearLevel = yearLevel;
        }
    }
}