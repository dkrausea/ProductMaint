using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Markup;

namespace OOP101_CS
{
  public class MyWindow : Window
  {
    /// <summary>
    /// Returns a true if the Window object is in design mode, or false if in runtime mode.
    /// </summary>
    /// <returns>Boolean</returns>
    public bool IsInDesignMode()
    {
      return DesignerProperties.GetIsInDesignMode(this);
    }

    /// <summary>
    /// Load and Merge a Resource Dictionary in a XAML file on disk into the current Window object
    /// </summary>
    /// <param name="fileName">The full path and file name of the XAML file.</param>
    public void LoadSamplesResource(string fileName)
    {
      ResourceDictionary dic = null;

      if (File.Exists(fileName))
      {
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
          dic = (ResourceDictionary)XamlReader.Load(fs);

        this.Resources.MergedDictionaries.Clear();
        this.Resources.MergedDictionaries.Add(dic);
      }
      else
        throw new ApplicationException("Can't open resource file: " + fileName + " in the method WPFCommon.OpenResourceDictionary().");
    }

    public string GetCurrentDirectory()
    {
      string path = null;

      path = AppDomain.CurrentDomain.BaseDirectory;
      if (path.IndexOf(@"\bin") > 0)
      {
        path = path.Substring(0, path.LastIndexOf(@"\bin"));
      }

      return path;
    }
  }
}
