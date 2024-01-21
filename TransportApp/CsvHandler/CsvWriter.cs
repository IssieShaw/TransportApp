using TransportApp.Transport;

namespace TransportApp.CsvHandler
{
    public static class CsvHandler
    {
        private static AppConfig _appConfig = new AppConfig();

        public static void Init(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public static void WriteToCsv<T>(List<T> items,
                                        string fileName) where T : class
        {
            var folder = _appConfig.CsvFolderPath;
            var filePath = Path.Combine(folder, fileName);

            // Ensure folder exists
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            try
            {
                // Write to CSV file
                // Snippet generated using example from: https://codereview.stackexchange.com/questions/249241/creating-a-csv-stream-from-an-object
                using (var writer = new StreamWriter(filePath))
                {
                    // Write header
                    var properties = typeof(T).GetProperties();
                    var columnNames = new List<string>();
                    foreach (var property in properties)
                    {
                        if (property.Name == "Dimensions")
                        {
                            columnNames.Add("LengthMM");
                            columnNames.Add("WidthMM");
                            columnNames.Add("HeightMM");
                        }
                        else
                        {
                            columnNames.Add(property.Name);
                        }
                    }
                    var header = string.Join(",", columnNames);
                    writer.WriteLine(header);

                    // Write data
                    foreach (var item in items)
                    {
                        var values = new List<string>();
                        foreach (var property in typeof(T).GetProperties())
                        {
                            if (property.Name == "Dimensions")
                            {
                                var dimensionsValue = property.GetValue(item) as VehicleDimensions; // Replace YourDimensionsType with the actual type
                                values.Add(dimensionsValue?.LengthMM.ToString() ?? "N/A");
                                values.Add(dimensionsValue?.WidthMM.ToString() ?? "N/A");
                                values.Add(dimensionsValue?.HeightMM.ToString() ?? "N/A");
                            }
                            else
                            {
                                var value = property.GetValue(item)?.ToString() ?? "N/A";
                                values.Add(value);
                            }
                        }
                        var line = string.Join(",", values);
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"CSV {fileName} successfully written to '{filePath}'.");
            }
            catch (IOException ex)
            {
                // https://learn.microsoft.com/en-us/dotnet/api/system.io.ioexception?view=net-8.0
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}