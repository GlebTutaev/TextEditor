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
        public static string path = $@"{AppDomain.CurrentDomain.BaseDirectory}\data/";

        public MainWindow()
        {
            InitializeComponent();
            var dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.*");
            Files.ItemsSource = files;
        }

        public void OpenFile(string file)
        {
            try
            {
                string s = $"{file}";
                TextRange tr = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd);
                using (var a = File.OpenRead(s))
                {
                   if (s.ToLower().EndsWith(".txt"))
                        tr.Load(a, System.Windows.DataFormats.Text);
                    else
                        tr.Load(a, System.Windows.DataFormats.Xaml);
                    a.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void CreateFile(string file) // Я не знаю по какой причине имя файлов невидимое, но они есть в списке(только при создании =) )
        {
            try
            {
                string s = $"{path}{file}.txt";
                TextRange range = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd);
                using (var a = File.Create(s))
                {
                    range.Save(a, DataFormats.Text);
                    a.Close();
                }
                var dir = new DirectoryInfo(path);
                FileInfo[] files = dir.GetFiles("*.*");
                Files.ItemsSource = files;
                Files.DisplayMemberPath = "Имя";
                MessageBox.Show($"Файл {file} создан!\n{s}");
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
                string s = $"{filename}";
                TextRange range = new TextRange(TextEditor.Document.ContentStart, TextEditor.Document.ContentEnd);
                using (FileStream f = new FileStream(s, FileMode.OpenOrCreate))
                {
                    range.Save(f, DataFormats.Text);
                    f.Close();
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
                string s = $"{filename}";
                File.Delete(s);
                var dir = new DirectoryInfo(path);
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
            Create create = new Create();
            if (create.ShowDialog() == true)
            {
                filename = create.FileName;
                CreateFile(filename);
            }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            string s = Files.SelectedItem.ToString();

            OpenFile(s);
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

        

    }
}

