using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using SceneObjects;

namespace Test1547
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = args.Length > 0 ? args[0] : "scene.txt";
            string outputFile = args.Length > 1 ? args[1] : "output.bmp";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Error: File '{inputFile}' not found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(inputFile);
                if (lines.Length == 0)
                {
                    Console.WriteLine("Error: The input file is empty.");
                    return;
                }

                string[] windowCoordsStr = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (windowCoordsStr.Length != 4)
                {
                    Console.WriteLine("Error: The first line must contain 4 window coordinates: x1 y1 x2 y2.");
                    return;
                }

                int winX1 = int.Parse(windowCoordsStr[0]);
                int winY1 = int.Parse(windowCoordsStr[1]);
                int winX2 = int.Parse(windowCoordsStr[2]);
                int winY2 = int.Parse(windowCoordsStr[3]);

                // Calculate image dimensions
                int width = Math.Abs(winX2 - winX1);
                int height = Math.Abs(winY2 - winY1);
                
                if (width == 0 || height == 0)
                {
                     Console.WriteLine("Error: Width or height of the window cannot be 0.");
                     return;
                }

                List<SceneObjects.Object> objects = new List<SceneObjects.Object>();

                // Parse objects
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i].Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string type = parts[0].ToLower();

                    try
                    {
                        switch (type)
                        {
                            case "point":
                                objects.Add(new SceneObjects.Point(int.Parse(parts[1]), int.Parse(parts[2])));
                                break;
                            case "rect":
                                objects.Add(new SceneObjects.Rect(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])));
                                break;
                            case "hline":
                                objects.Add(new SceneObjects.HLine(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                                break;
                            case "vline":
                                objects.Add(new SceneObjects.VLine(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                                break;
                            case "circle":
                                objects.Add(new SceneObjects.Circle(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
                                break;
                            case "triangle":
                                objects.Add(new SceneObjects.Triangle(int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                                break;
                            default:
                                Console.WriteLine($"Warning: Unknown object type '{type}' at line {i + 1}");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error parsing line {i + 1} '{line}': {ex.Message}");
                    }
                }

                // Render
                using (Bitmap bitmap = new Bitmap(width, height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(Color.White);
                        
                        int minX = Math.Min(winX1, winX2);
                        int minY = Math.Min(winY1, winY2);
                        
                        g.TranslateTransform(-minX, -minY);

                        using (Pen pen = new Pen(Color.Black, 2))
                        {
                            foreach (var obj in objects)
                            {
                                obj.Draw(g, pen);
                            }
                        }
                    }
                    
                    if (OperatingSystem.IsWindows())
                    {
#pragma warning disable CA1416 // Validate platform compatibility
                        bitmap.Save(outputFile, System.Drawing.Imaging.ImageFormat.Bmp);
#pragma warning restore CA1416 // Validate platform compatibility
                    }
                    else
                    {
                        bitmap.Save(outputFile, System.Drawing.Imaging.ImageFormat.Bmp);
                    }
                }

                Console.WriteLine($"Successfully rendered scene with {objects.Count} objects to '{outputFile}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}