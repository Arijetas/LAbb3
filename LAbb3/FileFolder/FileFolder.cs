using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LAbb3
{
    class FileFolder    //DET BLIR INGEN JSON FIL I FOLDERN????????????? 
    {
        public static List<Question> questions = new List<Question>();

        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string path1 = "QuizListor.json";
        public static string SpecificFolder => Path.Combine(path, "QuizListor");

        public static void CreateFolder()
        {
            Directory.CreateDirectory(SpecificFolder);
        }


        public static async Task Save (string quizName,List<Question> Lista)
        {
            path1 = quizName;
            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(SpecificFolder, path1)))
            {
                await streamWriter.WriteAsync(JsonSerializer.Serialize(Lista));
            }
        }

        public static List<Question> ListofQuestions()
        {
            using (var streamReader = new StreamReader(Path.Combine(path, path1)))
            {
                var text = streamReader.ReadToEnd();

                List<Question> ListofQuestions = JsonSerializer.Deserialize<List<Question>>(text);
                return ListofQuestions;
            }
        }
    }
}





