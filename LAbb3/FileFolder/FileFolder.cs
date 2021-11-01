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
    class FileFolder
    {
        public static List<Question> Lista = new List<Question>();

        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static string path1 = "QuizListor";
        public static string SpecificFolder => Path.Combine(path, "QuizListor");

        static void CreateFolder()
        {
            Directory.CreateDirectory(SpecificFolder);
        }


        public static async Task Save (List<Question> Lista)
        {

            using (StreamWriter streamWriter = new StreamWriter(Path.Combine(path, path1)))
            {
                await streamWriter.WriteAsync(JsonSerializer.Serialize(Lista));
            }
        }

        public static List<Question> ListofQuestions()
        {
            using (var streamReader = new StreamReader(Path.Combine(path, path1)))
            {
                var text = streamReader.ReadToEnd();

                List<Question> listOfQuizzes = JsonSerializer.Deserialize<List<Question>>(text);
                return listOfQuizzes;
            }
        }
    }
}





