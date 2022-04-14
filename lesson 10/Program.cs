namespace lesson_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataPrinter dataPrinter = new DataPrinter();
            dataPrinter.PrintProductList();
            //--------------------------------------------------------------------
            // sukurti nauja uzsakyma ir atvaizduoti jo informacija su produktais
            //--------------------------------------------------------------------
            dataPrinter.PrintOrdersData();
        }
    }
}
