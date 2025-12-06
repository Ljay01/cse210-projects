public class ActivityLogger
    {
        private Dictionary<string, int> _counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private string _filePath;

        public ActivityLogger(string filePath = "activity_log.txt")
        {
            _filePath = filePath;
            Load();
        }

        private void Load()
        {
            if (!File.Exists(_filePath)) return;
            try
            {
                foreach (var line in File.ReadAllLines(_filePath))
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int c))
                        _counts[parts[0]] = c;
                }
            }
            catch
            {
                // ignore read errors for simplicity
            }
        }

        private void Save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_filePath, false))
                {
                    foreach (var kv in _counts)
                    {
                        sw.WriteLine($"{kv.Key}|{kv.Value}");
                    }
                }
            }
            catch
            {
                // ignore write errors for simplicity
            }
        }

        public void Increment(string activityName)
        {
            if (string.IsNullOrWhiteSpace(activityName)) return;
            if (!_counts.ContainsKey(activityName)) _counts[activityName] = 0;
            _counts[activityName]++;
            Save();
        }

        public int GetCount(string activityName)
        {
            if (string.IsNullOrWhiteSpace(activityName)) return 0;
            return _counts.ContainsKey(activityName) ? _counts[activityName] : 0;
        }

        public void PrintSummary()
        {
            Console.WriteLine("Activity Log Summary:");
            if (_counts.Count == 0)
            {
                Console.WriteLine("  No activities recorded yet.");
                return;
            }

            foreach (var kv in _counts)
                Console.WriteLine($"  {kv.Key}: {kv.Value}");
        }
    }
