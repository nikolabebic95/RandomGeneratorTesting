using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Windows.Forms;
using RandomGeneratorTesting.RandomGenerators;
using RandomGeneratorTesting.RandomnessTests;

namespace RandomGeneratorTesting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // ReSharper disable once CoVariantArrayConversion
            generatorChooser.Items.AddRange(RandomGenerator.Dictionary.Keys.ToArray());
            generatorChooser.SelectedIndex = 0;
            randomGenerator = RandomGenerator.Dictionary[(string) generatorChooser.SelectedItem];
        }

        private RandomGenerator randomGenerator;

        private readonly List<Vector2> points = new List<Vector2>();
        private readonly List<float> floats = new List<float>();

        private static readonly Color PointsColor = Color.MediumVioletRed;
        private static readonly Brush PointsBrush = new SolidBrush(PointsColor);
        private const int NumOfPoints = 100000;
        private const int NumOfTestFloats = 10000;

        private void RandomPanelPaint(object sender, PaintEventArgs e)
        {
            points.ForEach(point => e.Graphics.FillRectangle(PointsBrush, point.X * Width, point.Y * Height, 1, 1));
        }

        private void GeneratorChooserSelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (string) generatorChooser.SelectedItem;
            randomGenerator = RandomGenerator.Dictionary[item];
        }

        private void DrawButtonClick(object sender, EventArgs e)
        {
            drawButton.Enabled = false;
            points.Clear();

            for (var i = 0; i < NumOfPoints; i++)
            {
                points.Add(randomGenerator.GenerateVector2());
            }

            Refresh();
            drawButton.Enabled = true;
        }

        private void TestButtonClick(object sender, EventArgs e)
        {
            TestButton.Enabled = false;
            floats.Clear();
            for (var i = 0; i < NumOfTestFloats; i++)
            {
                floats.Add(randomGenerator.GenerateFloat());
            }

            TestSummary.Items.Clear();

            foreach (var test in RandomnessTest.Dictionary.Values)
            {
                var result = test.Test(floats);
                TestSummary.Items.Add(result);
                TestSummary.Refresh();
            }

            TestButton.Enabled = true;
        }
    }
}
