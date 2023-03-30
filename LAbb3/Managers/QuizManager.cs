using LAbb3.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAbb3.Managers
{
    public class QuizManager
    {
        private ObservableCollection<Quiz> _allQuizzes;

        public ObservableCollection<Quiz> AllQuizzes
        {
            get { return _allQuizzes; }
            set { _allQuizzes = value; }
        }

        public QuizManager()
        {
            _allQuizzes = new ObservableCollection<Quiz>();
        }

        private readonly string _filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private readonly string _fileName = "Quizzes.json";

        public async Task SaveQuizzesToFile()
        {
            using FileStream streamWriter = File.Create(Path.Combine(_filePath, _fileName));
            JsonSerializerOptions options = new() { WriteIndented = true };
            await JsonSerializer.SerializeAsync(streamWriter, AllQuizzes, options);
            await streamWriter.DisposeAsync();
        }

        public async Task<List<Quiz>> LoadQuizAsync()
        {
            try
            {
                using FileStream streamReader = File.OpenRead(Path.Combine(_filePath, _fileName));
                var quizzes = await JsonSerializer.DeserializeAsync<List<Quiz>>(streamReader);
                return quizzes;
            }
            catch
            {
                var questions = new Quiz("Kaffe Quiz");
                questions.AddQuestion("Folk började dricka kaffe...", 2, "Under första världskriget", "På Kristi tid",
                    "På 900-talet");
                questions.AddQuestion("Det mesta kaffet produceras i...", 1, "Vietnam", "Brasilien", "Columbia");
                questions.AddQuestion("Vilken dryck dricker vi när vi blandar ångad mjölk med espresso?", 0, "Latte", "Cappuccino", "Mocha");
                var quizzes = new List<Quiz>();
                quizzes.Add(questions);
                return quizzes;
            }
        }
    }
}
