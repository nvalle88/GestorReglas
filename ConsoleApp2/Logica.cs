namespace ConsoleApp2
{
    public class Logica
    {
        public class TestClass
        {
            private string caption = "A Default caption";
            public string Caption
            {
                get { return caption; }
                set
                {
                    if (caption != value)
                    {
                        caption = value;
                    }
                }
            }
        }
        public Logica()
        {
            
        }
    }
}
