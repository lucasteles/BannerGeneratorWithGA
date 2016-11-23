using GeneticAlgorithm.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BannerGeneratorWithGeneticAlgorithm.Models
{
    public class BannerConfig
    {
        public int Id { get; set; }
        public Point ImagePosition { get; set; }
        public Point LabelPosition { get; set; }
        public RGB BackgroundColor { get; set; }
        public RGB ForegroundColor { get; set; }
        public Images Image { get; set; }
        public Fonts Font { get; set; }
        public long Score { get; set; }

        public BannerConfig(IGenome genome)
        {
            var gen = genome.Gens;
            if (gen.Count() != 12)
                throw new Exception("Invalid Genome!");

            ImagePosition = new Point();
            LabelPosition = new Point();
            BackgroundColor = new RGB();
            ForegroundColor = new RGB();

            ImagePosition.X = ParseByte(gen[0]);
            ImagePosition.Y = ParseByte(gen[1]);
            LabelPosition.X = ParseByte(gen[2]);
            LabelPosition.Y = ParseByte(gen[3]);

            BackgroundColor.R =(byte)gen[4];
            BackgroundColor.G =(byte)gen[5];
            BackgroundColor.B =(byte)gen[6];

            ForegroundColor.R = (byte)gen[7];
            ForegroundColor.G = (byte)gen[8];
            ForegroundColor.B = (byte)gen[9];


            Image = ByteToEnum<Images>(gen[10]);
            Font  = ByteToEnum<Fonts>(gen[11]);

            Score = genome.Score;

        }

        private T ByteToEnum<T>(int value) where T : struct, IConvertible
        {
            
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var proprotion = ((double)ParseByte(value))/100;
            var values = Enum.GetNames(typeof(T));

            var enumItem = values.GetValue(
                            (int)Math.Round(proprotion * (values.Length-1))
                        );

            T ret;
            Enum.TryParse(enumItem.ToString(), out ret);

            return ret;

        }

        private int ParseByte(int v)
        {
            // regra de 3
            return (v * 100) / 255;
        }

    }


    public enum Images
    {
        Logo1,
        Logo2,
        Logo3
    }

    public enum Fonts
    {
        Font1,
        Font2,
        Font3
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class RGB
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
    }



}