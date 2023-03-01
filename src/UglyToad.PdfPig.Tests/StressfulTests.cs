namespace UglyToad.PdfPig.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using Xunit;

    public class StressfulTests
    {
        [Fact(Skip = "For debug")]
        public void Run()
        {
            string[] paths = Directory.GetFiles("C:/Users/Bob/Document Layout Analysis/stressful corpus", "*.pdf", SearchOption.AllDirectories);
            foreach (var path in paths)
            {
                try
                {
                    using (var document = PdfDocument.Open(path, new ParsingOptions { UseLenientParsing = true }))
                    {
                        for (var i = 0; i < document.NumberOfPages; i++)
                        {
                            try
                            {
                                var page = document.GetPage(i + 1);
                                var images = page.GetImages().ToList();
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine("Error page\n" + ex);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error doc\n" + ex);
                }
            }
        }


    }
}
