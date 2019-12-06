using System;
using System.Collections.Generic;
using CommandLine;
using TagsCloud.Visualization.ColorDefiner;
using TagsCloud.Visualization.SizeDefiner;

namespace TagsCloud
{
    public class Options
    {
        public static Options Parse(IEnumerable<string> args)
        {
            var options = new Options();
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o => options = o)
                .WithNotParsed(e => throw new ArgumentException("Wrong arguments"));
            return options;
        }

        [Option('f', "file", Required = false, Default = @"input1.txt",HelpText = "The file from which we take the words")]
        public string File { get; set; }

        [Option("font", Required = false, Default = "Arial", HelpText = "Defines font of words.")]
        public string Font { get; set; }

        [Option("minFS", Required = false, Default = 10, HelpText = "Min font-size.")]
        public int MinFontSize { get; set; }

        [Option("maxFS", Required = false, Default = 200, HelpText = "Max font-size.")]
        public int MaxFontSize { get; set; }

        [Option("bgcolor", Required = false, Default = "Black", HelpText = "Color of the background.")]
        public string BackgroundColor { get; set; }

        [Option("tagscolor", Required = false, Default = ColorDefinersCollection.Random,
            HelpText = "Color of tags" +
                       "Possible types are: Random")]
        public ColorDefinersCollection ColorDefiner { get; set; }


        [Option("sizedefiner", Required = false, Default = SizeDefinersCollection.Frequency, HelpText =
            "Type of the size definer." +
            "Possible types are: Frequency")]
        public SizeDefinersCollection SizeDefiner { get; set; }
    }
}