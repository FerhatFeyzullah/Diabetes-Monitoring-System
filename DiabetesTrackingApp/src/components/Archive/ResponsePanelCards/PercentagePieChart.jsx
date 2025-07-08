import { useEffect } from "react";
import { useSelector } from "react-redux";
import { PieChart, Pie, Cell, Tooltip, Legend } from "recharts";

function PercentageChart({ patId }) {
  const { percentages } = useSelector((store) => store.dailyStatus);
  const { prescriptionPercentage, dietPercentage, exercisePercentage } =
    percentages;

  const data = [
    {
      name: "Reçete",
      value: Number((prescriptionPercentage || "0").replace(",", ".")),
    },
    { name: "Diyet", value: Number((dietPercentage || "0").replace(",", ".")) },
    {
      name: "Egzersiz",
      value: Number((exercisePercentage || "0").replace(",", ".")),
    },
  ];

  const COLORS = ["#8884d8", "#82ca9d", "#ffc658"];

  useEffect(() => {
    console.log(percentages);
  }, [percentages]);

  return (
    <>
      {patId ? (
        <div style={{ border: "none", outline: "none", boxShadow: "none" }}>
          <PieChart width={600} height={400} style={{ outline: "none" }}>
            <Pie
              data={data}
              dataKey="value"
              nameKey="name"
              cx="50%"
              cy="50%"
              outerRadius={100}
              label
            >
              {data.map((_, index) => (
                <Cell
                  key={`cell-${index}`}
                  fill={COLORS[index % COLORS.length]}
                />
              ))}
            </Pie>
            <Tooltip />
            <Legend />
          </PieChart>
        </div>
      ) : (
        <div
          style={{
            fontFamily: "sans-serif",
            fontSize: "17px",
            fontWeight: "bold",
          }}
        >
          Veri görüntüleme işlemi için lütfen önce bir hasta seçimi yapınız.
        </div>
      )}
    </>
  );
}

export default PercentageChart;
