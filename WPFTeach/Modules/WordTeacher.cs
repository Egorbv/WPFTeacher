using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using WPFTeach.Controllers;
using WPFTeach.Views;

namespace WPFTeach.Modules
{
    public	class WordTeacher
    {
		Dictionary<string, List<WordTeqacherItem>> _categories;

		public IEnumerable<string> GetCategories()
		{
			foreach (var i in _categories)
			{
				yield return i.Key;
			}
		}

		public WordTeacher()
		{
			_categories = new Dictionary<string, List<WordTeqacherItem>>();
		}

		public UIElement CreateView()
		{
			var controller = new WordTeacherRepeatWordController(this);
			var view = new WordTeacherRepeatWord();
			view.DataContext = controller;
			return view;
		}

		public void Load(string fileName)
		{
			var doc = new XmlDocument();
			doc.Load(fileName);

			var categories = doc.SelectNodes("//category");
			for (var categoryIndex = 0; categoryIndex < categories.Count; categoryIndex++)
			{
				var category = categories[categoryIndex];
				var categoryName = category.Attributes["name"].Value;
				_categories.Add(categoryName, new List<WordTeqacherItem>());
				for (var childIndex = 0; childIndex < category.ChildNodes.Count; childIndex++)
				{
					var node = category.ChildNodes[childIndex];
					var item = new WordTeqacherItem()
					{
						Word = node.Attributes["word"].Value,
						Trnascription = node.Attributes["transcription"].Value,
						Translate = node.Attributes["translate"].Value,
					};
					_categories[categoryName].Add(item);
				}
			}
		}
    }


	public class WordTeqacherItem
	{
		public string Word { get; set; }

		public string Translate { get; set; }

		public string Trnascription { get; set; }

		public string Examples { get; set; }

		public string SoundPath { get; set; }

		public int CorrectAnswers { get; set; }

	}
}
