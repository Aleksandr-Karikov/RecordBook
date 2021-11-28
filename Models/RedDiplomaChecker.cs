using RecordBook.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RecordBook.Models
{
    public static class RedDiplomaCalculator
    {

        private static RecBook _recordBook;
        private static RecordBkContext context;
        private static int _fiveProbability;
        private static int _fourProbability;
        private static Dictionary<int, int> Marks = new Dictionary<int, int>
        {
            {2, 0},
            {3, 0},
            {4, 0},
            {5, 0}
        };
        public static void CalculateProbabilityRedDiploma(RecBook recordBook)
        {
            _recordBook = recordBook;

            try
            {
                ClearMarks();
                SetMarks(); 
                Calculate();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private static void ClearMarks()
        {
            for (int i = 2; i <= 5; i++)
                Marks[i] = 0;
        }

        private static void SetMarks()
        {
            try
            {
                using(RecordBkContext context = new RecordBkContext())
                {
                    var fives = context.Marks.Count(x => x.mark == "5" && x.RecordBkID == _recordBook.Number);
                    var fours = context.Marks.Count(x => x.mark == "4" && x.RecordBkID == _recordBook.Number);
                    var threes = context.Marks.Count(x => x.mark == "3" && x.RecordBkID == _recordBook.Number);
                    var twos = context.Marks.Count(x => x.mark == "2" && x.RecordBkID == _recordBook.Number);
                    Marks[2] = twos;
                    Marks[3] = threes;
                    Marks[4] = fours;
                    Marks[5] = fives;
                }
                
            }
            catch (InvalidCastException)
            {
                throw new Exception("Есть не выставленные оценки!");
            }
            catch (NullReferenceException)
            {
                throw new Exception("Выберите зачетную книжку!");
            }
        }
        private static void Calculate()
        {
            int sumOfCountMarks = Marks.Values.Sum();

            if (sumOfCountMarks != 0)
            {
                _fiveProbability = Marks[5] * 100 / sumOfCountMarks;
                _fourProbability = Marks[4] * 100 / sumOfCountMarks;
            }

            if (Marks[3] != 0 || Marks[2] != 0)
            {
                MessageBox.Show("Получение диплома невозможно, так как в зачетной книжке присутствуют 3 либо 2!");
            }
            else if (_fiveProbability >= 75 && _fourProbability <= 25)
            {
                MessageBox.Show(
                    $"Возможно получение красного диплома!\nПроцентное соотноошение 5 и 4 = {_fiveProbability}% / {_fourProbability}%");
            }
            else
            {
                MessageBox.Show(
                    $"Получение диплома невозможно!\nПроцентное соотноошение 5 и 4 = {_fiveProbability}% / {_fourProbability}%");
            }
        }
    }
}
