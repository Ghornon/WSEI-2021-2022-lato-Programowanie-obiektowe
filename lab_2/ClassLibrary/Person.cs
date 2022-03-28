using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Person : IEquatable<Person>
    {
        protected string name;
        protected int age;
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Person otherPerson = obj as Person;
            if (otherPerson == null)
                return false;
            else
                return Equals(otherPerson);
        }
        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Age == other.Age)
                return true;
            else
                return false;
        }

        public override int GetHashCode() => HashCode.Combine(Name, Age);

        public override string ToString() => base.ToString();
    }

    public class Student : Person, IEquatable<Student>
    {
        protected string group;
        protected List<Task> tasks = new List<Task>();
        public string Group { get => group; set => group = value; }

        public Student(string name, int age, string group) : base(name, age)
        {
            Group = group;
        }

        public Student(string name, int age, string group, List<Task> tasks) : base(name, age)
        {
            Group = group;
            this.tasks = tasks;
        }

        public void AddTask(string taskName, TaskStatus taskStatus)
        {
            var task = new Task(taskName, taskStatus);
            tasks.Add(task);
        }

        public void RemoveTask(int index)
        {
            tasks.RemoveAt(index);
        }

        public void UpdateTask(int index, TaskStatus taskStatus)
        {
            var task = tasks[index];
            task.Status = taskStatus;

            tasks.Insert(index, task);
            tasks.RemoveAt(index + 1);
        }

        public string RenderTasks(string prefix = "\t")
        {
            string result = "";

            for (int i = 0; i < tasks.Count; i++)
            {
                result += "\r\n" + prefix + i.ToString() + ". " + tasks[i];
            }

            return result;
        }

        public override string ToString() => $"Student: {Name} ({Age} y.o.)\r\nGroup: {Group}\r\nTasks: {RenderTasks()}";

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Student otherPerson = obj as Student;
            if (otherPerson == null)
                return false;
            else
                return Equals(otherPerson);
        }
        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            if (Name == other.Name && Age == other.Age && Group == other.Group && RenderTasks() == other.RenderTasks())
                return true;
            else
                return false;
        }
        public override int GetHashCode() => HashCode.Combine(Name, Age, Group, tasks);
    }

    public class Teacher : Person
    {
        public Teacher(string name, int age) : base(name, age)
        {

        }

        public override string ToString() => $"Teacher: {Name} ({Age} y.o.)";
    }

}
