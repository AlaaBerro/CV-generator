namespace CV.Services
{
    public class ComputeGradeService
    {
       
        public int CalculateGrade(List<string> skills , string gender)
        {
            int grade = 0;
            foreach (string skill in skills)
            {
                if(gender.Equals("Male"))   grade += 5;
                
                else    grade += 10;
                    
            }
            return grade; // Replace with your actual calculation logic
        }


        }
    }

