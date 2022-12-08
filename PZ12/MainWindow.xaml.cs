using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace PZ12
{/// <summary>
 /// Логика взаимодействия для MainWindow.xaml
 /// </summary>
    public partial class MainWindow : Window
    {
        private object temp;
        public int Start { get; set; }
        public static string path = Convert.ToString(@"D:\VsProjects\PZ12\PZ12\data/");
        public MainWindow()
        {
            InitializeComponent();
            var dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.*");
            Files.ItemsSource = files;
        }

        public void OpenFile(string filename)
        {
            try
            {
                string fl = $"{path}{filename}";
                TextRange range = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd);
                using (var fs = File.OpenRead(fl))
                {
                   if (fl.ToLower().EndsWith(".txt"))
                        range.Load(fs, System.Windows.DataFormats.Text);
                    else
                        range.Load(fs, System.Windows.DataFormats.Xaml);
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CreateFile(string filename)
        {
            try
            {
                string fl = $"{path}{filename}.txt";
                TextRange range = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd);
                using (var fs = File.Create(fl))
                {
                    range.Save(fs, DataFormats.Text);
                    fs.Close();
                }
                var dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles("*.*");
                Files.ItemsSource = files;
                Files.DisplayMemberPath = "Name";
                MessageBox.Show($"Файл {filename} был создан!\n{fl}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void SaveFile(string filename)
        {
            try
            {
                string fl = $"{path}{filename}";
                TextRange range = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd);
                using (FileStream fs = new FileStream(fl, FileMode.OpenOrCreate))
                {
                    range.Save(fs, DataFormats.Rtf);
                    fs.Close();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void DeleteFile(string filename)
        {
            try
            {
                string fl = $"{path}{filename}";
                File.Delete(fl);
                var dir = new System.IO.DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles("*.*");
                Files.ItemsSource = files;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            string filename;
            Create createFileWindow = new Create();
            if (createFileWindow.ShowDialog() == true)
            {
                filename = createFileWindow.FileName;
                CreateFile(filename);
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string s = Files.SelectedItem.ToString();

            SaveFile(s);
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string s = Files.SelectedItem.ToString();

            DeleteFile(s);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            UpdateCP();

        }

        private void UpdateCP()
        {
            TextPointer tp1 = TextEditor.Selection.Start.GetLineStartPosition(0);
            TextPointer tp2 = TextEditor.Selection.Start;

            int column = tp1.GetOffsetToPosition(tp2);

            int someBigNumber = int.MaxValue;
            int lineMoved, currentLineNumber;
            TextEditor.Selection.Start.GetLineStartPosition(-someBigNumber, out lineMoved);
            currentLineNumber = -lineMoved;

            CursorPosition.Text = "Line: " + currentLineNumber.ToString() + " Column: " + column.ToString();
        }

        private void SelectionChanged(object sender, RoutedEventArgs e)
        {
            temp = TextEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnB.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = TextEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnI.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = TextEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnU.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}

