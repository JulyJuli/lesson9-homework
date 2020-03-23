namespace HW2103
{
    public class Students : Person
    {
        public static int counter = 0;
        public Students(string firstname, string surname, int age, string specialty) : base (firstname, surname, age)
        {
            Specialty = specialty;
            counter++;            
        }
        
        public string Specialty { get; }      

        public override string Print()
        {            
            return $"Name: {Firstname.PadRight(9)} | Surname: {Surname.PadRight(9)} | Age: {Age} | Specialty: {Specialty}";
        }

        public string Count()
        {
            return $"{counter}";
        }
    }
}
