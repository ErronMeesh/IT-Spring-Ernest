using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

// Interface definition
public interface IEntrant
{
    string Name { get; set; }
    void Register();
    void PayTuition();
}

// Abstract class definition
public abstract class Student : IEntrant
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string StudentId { get; set; }

    public abstract void AttendClass();
    public abstract void Study();

    public void Register()
    {
        Console.WriteLine("Student registration completed.");
    }

    public void PayTuition()
    {
        Console.WriteLine("Tuition payment completed.");
    }
}

// Main program
class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.Run(new MainForm());
    }
}

// Windows Form class
public class MainForm : Form
{
    private ComboBox classComboBox;
    private Button executeButton;

    private List<Type> classTypes;
    private Dictionary<string, MethodInfo[]> classMethods;

    public MainForm()
    {
        classComboBox = new ComboBox();
        classComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        classComboBox.SelectedIndexChanged += ClassComboBox_SelectedIndexChanged;

        executeButton = new Button();
        executeButton.Text = "Execute";
        executeButton.Click += ExecuteButton_Click;

        Controls.Add(classComboBox);
        Controls.Add(executeButton);

        LoadClassLibrary();

        foreach (Type classType in classTypes)
        {
            classComboBox.Items.Add(classType.Name);
        }
    }

    private void LoadClassLibrary()
    {
        string pathToLibrary = "C:/Users/abrak/source/repos/IT6TaskTEST1/ClassLibrary6ITT/bin/Debug/netcoreapp3.1/ClassLibrary6ITT.dll"; // Replace with the actual path to your class library

        Assembly assembly = Assembly.LoadFrom(pathToLibrary);

        classTypes = assembly.GetTypes()
            .Where(type => typeof(Student).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract)
            .ToList();

        classMethods = new Dictionary<string, MethodInfo[]>();

        foreach (Type classType in classTypes)
        {
            MethodInfo[] methods = classType.GetMethods();
            classMethods.Add(classType.Name, methods);
        }
    }

    private void ClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedClassName = classComboBox.SelectedItem.ToString();
        MethodInfo[] methods = classMethods[selectedClassName];

        ClearDynamicControls();

        int yPosition = 70;

        foreach (MethodInfo method in methods)
        {
            if (method.DeclaringType != typeof(object))
            {
                Label label = new Label();
                label.Text = method.Name;
                label.AutoSize = true;
                label.Location = new System.Drawing.Point(30, yPosition);
                Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Name = method.Name;
                textBox.Location = new System.Drawing.Point(150, yPosition);
                Controls.Add(textBox);

                yPosition += 30;
            }
        }

        // Add the Execute button dynamically
        Button executeButton = new Button();
        executeButton.Text = "Execute";
        executeButton.Location = new System.Drawing.Point(150, yPosition);
        executeButton.Click += ExecuteButton_Click;
        Controls.Add(executeButton);
    }

    private void ExecuteButton_Click(object sender, EventArgs e)
    {
        string selectedClassName = classComboBox.SelectedItem.ToString();
        Type selectedClassType = classTypes.FirstOrDefault(type => type.Name == selectedClassName);

        if (selectedClassType != null)
        {
            object instance = Activator.CreateInstance(selectedClassType);

            MethodInfo[] methods = classMethods[selectedClassName];

            foreach (MethodInfo method in methods)
            {
                if (method.DeclaringType != typeof(object))
                {
                    string methodName = method.Name;
                    string textBoxName = methodName;

                    TextBox textBox = Controls.Find(textBoxName, true).FirstOrDefault() as TextBox;

                    if (textBox != null)
                    {
                        string parameterValue = textBox.Text;
                        object[] parameters = new object[] { parameterValue };

                        method.Invoke(instance, parameters);
                    }
                }
            }
        }
    }

    private void ClearDynamicControls()
    {
        for (int i = Controls.Count - 1; i >= 0; i--)
        {
            if (Controls[i] is Label || Controls[i] is TextBox || Controls[i] is Button)
            {
                Controls.RemoveAt(i);
            }
        }
    }
}
