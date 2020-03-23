namespace Teachers_And_Students
{
    internal class StudentType
    {
        internal const int _minAge = 16;
        internal const int _maxAge = 50;
        private int _age;

        public string ID { get; set; }
        public string Name { get; set; }
        //public int Age { get; }
        public int Age
        {
            get
            {
                return this._age;
            }
            
            set
            {
                if (value >= _minAge && value <= _maxAge)
                {
                    this._age = value;
                }
                else
                {
                    System.Console.WriteLine("Wrong age. The student should be not younger than {0} and not older than {1}.", _minAge, _maxAge);
                    Menu.ShowMenu();
                    return;
                }
            }
        }
    }
}
