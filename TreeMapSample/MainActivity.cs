using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Org.Json;
using Com.Syncfusion.Treemap;
using Android.Graphics;

namespace TreeMapSample
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SfTreeMap treeMap = new SfTreeMap(this);
            treeMap.ColorValuePath = "Growth";
            treeMap.WeightValuePath = "Population";
            treeMap.LayoutType = Com.Syncfusion.Treemap.Enums.LayoutType.Squarified;
            treeMap.ShowTooltip = true;

            LeafItemSetting leafItemSetting = new LeafItemSetting();
            leafItemSetting.ShowLabels = true;
            leafItemSetting.Gap = 2;
            leafItemSetting.LabelPath = "Country";
            treeMap.LeafItemSettings = leafItemSetting;

            TreeMapFlatLevel flatLevel = new TreeMapFlatLevel();
            flatLevel.HeaderHeight = 20;
            flatLevel.GroupPath = "Continent";
            flatLevel.GroupGap = 5;
            flatLevel.ShowHeader = true;
            flatLevel.GroupStrokeColor = Color.Gray;
            flatLevel.GroupStrokeWidth = 1;
            flatLevel.HeaderStyle = new Style() { TextColor = Color.Black };
            treeMap.Levels.Add(flatLevel);

            LegendSetting legendSettings = new LegendSetting();
            legendSettings.ShowLegend = true;
            legendSettings.LegendSize = new Size(700, 45);
            legendSettings.LabelStyle = new Style() { TextColor = Color.Black };
            treeMap.LegendSettings = legendSettings;

            RangeColorMapping rangeColorMapping = new RangeColorMapping();

            Range range1 = new Range();
            range1.From = 0;
            range1.To = 1;
            range1.Color = Color.ParseColor("#77D8D8");
            range1.LegendLabel = "1 % Growth";

            Range range2 = new Range();
            range2.From = 0;
            range2.To = 2;
            range2.Color = Color.ParseColor("#AED960");
            range2.LegendLabel = "2 % Growth";

            Range range3 = new Range();
            range3.From = 0;
            range3.To = 3;
            range3.Color = Color.ParseColor("#FFAF51");
            range3.LegendLabel = "3 % Growth";

            Range range4 = new Range();
            range4.From = 0;
            range4.To = 4;
            range4.Color = Color.ParseColor("#F3D240");
            range4.LegendLabel = "4 % Growth";

            rangeColorMapping.Ranges.Add(range1);
            rangeColorMapping.Ranges.Add(range2);
            rangeColorMapping.Ranges.Add(range3);
            rangeColorMapping.Ranges.Add(range4);

            treeMap.LeafItemColorMapping = rangeColorMapping;
            treeMap.DataSource = GetDataSource();

            SetContentView(treeMap);
        }

        JSONArray GetDataSource()
        {
            JSONArray array = new JSONArray();
            array.Put(getJsonObject("Asia", "Indonesia", 3, 237641326));
            array.Put(getJsonObject("Asia", "Russia", 2, 152518015));
            array.Put(getJsonObject("North America", "United States", 4, 315645000));
            array.Put(getJsonObject("North America", "Mexico", 2, 112336538));
            array.Put(getJsonObject("North America", "Canada", 1, 35056064));
            array.Put(getJsonObject("South America", "Colombia", 1, 47000000));
            array.Put(getJsonObject("South America", "Brazil", 3, 193946886));
            array.Put(getJsonObject("Africa", "Nigeria", 2, 170901000));
            array.Put(getJsonObject("Africa", "Egypt", 1, 83661000));
            array.Put(getJsonObject("Europe", "Germany", 1, 81993000));
            array.Put(getJsonObject("Europe", "France", 1, 65605000));
            array.Put(getJsonObject("Europe", "UK", 1, 63181775));

            return array;
        }

        JSONObject getJsonObject(string continent, string country, double growth, double population)
        {
            JSONObject obj = new JSONObject();

            obj.Put("Continent", continent);
            obj.Put("Country", country);
            obj.Put("Growth", growth);
            obj.Put("Population", population);

            return obj;
        }

    }
}