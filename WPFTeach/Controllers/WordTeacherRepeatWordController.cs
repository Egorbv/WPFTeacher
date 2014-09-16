using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTeach.Modules;

namespace WPFTeach.Controllers
{
	public class WordTeacherRepeatWordController : BaseController
	{
		string _currentWord;
		string _transcription;
		WordTeacher _wordTeacher;
		ObservableCollection<string> _categories;

		public string CurrentWord
		{
			get
			{
				return _currentWord;
			}
			set
			{
				_currentWord = value;
				OnPropertyChange("CurrentWord");
			}
		}

		public ObservableCollection<string> Categories { get; private set; }

		public string Transcription
		{
			get
			{
				return _transcription;
			}
			set
			{
				_transcription = value;
				OnPropertyChange("Transcription");
			}
		}

		public ActionCommand ChangeCategoryCommand { get; private set; }

		public WordTeacherRepeatWordController(WordTeacher wordTeacher)
		{
			Categories = new ObservableCollection<string>();
			_wordTeacher = wordTeacher;

			ChangeCategoryCommand = new ActionCommand(n => _changeCategoryCommandCallback(n as string));

			foreach (var category in _wordTeacher.GetCategories())
			{
				Categories.Add(category);
			}
		}


		void _changeCategoryCommandCallback(string category)
		{
			var s = "eeeE";
		}
	}
}
