using ImageClassificationExampleML.Model;
using System;
using System.Linq;

namespace ImageClassificationExample
{
	class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Here are some categories that the model can recognize");
				foreach (var cat in Enum.GetValues(typeof(Category)))
				{
					Console.WriteLine(Enum.GetName(typeof(Category), cat));
				}


				Console.Write("\nPaste the image path which want to recognize: ");
				string source = Console.ReadLine();
				if (source == "exit")
				{
					break;
				}

				ModelInput sampleData = new ModelInput()
				{
					ImageSource = source,
				};

				var predictionResult = ConsumeModel.Predict(sampleData);

				Console.WriteLine($"ImageSource: {sampleData.ImageSource}");
				Console.WriteLine($"\n\nPredicted Label value {predictionResult.Prediction}");
				Console.WriteLine($"\nAccuracy: {predictionResult.Score.Max()}\n");
			}
			Console.WriteLine("=============== End of process, hit any key to finish ===============");
			Console.ReadKey();
		}
	}
}
