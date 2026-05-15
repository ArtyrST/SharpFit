export default function Dashboard() {
  return (
    <div
      style={{
        padding: "40px",
        fontFamily: "Arial",
        backgroundColor: "#f5f5f5",
        minHeight: "100vh",
      }}
    >
      <h1 style={{ color: "#333" }}>Fitness Tracker Dashboard</h1>

      <div
        style={{
          display: "grid",
          gridTemplateColumns: "repeat(auto-fit, minmax(250px, 1fr))",
          gap: "20px",
          marginTop: "30px",
        }}
      >
        <div
          style={{
            backgroundColor: "white",
            padding: "20px",
            borderRadius: "12px",
            boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
          }}
        >
          <h2>Calories</h2>
          <p>Track your daily calorie intake.</p>
        </div>

        <div
          style={{
            backgroundColor: "white",
            padding: "20px",
            borderRadius: "12px",
            boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
          }}
        >
          <h2>Water Intake</h2>
          <p>Monitor how much water you drink every day.</p>
        </div>

        <div
          style={{
            backgroundColor: "white",
            padding: "20px",
            borderRadius: "12px",
            boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
          }}
        >
          <h2>Weight Progress</h2>
          <p>View your weight changes and progress chart.</p>
        </div>

        <div
          style={{
            backgroundColor: "white",
            padding: "20px",
            borderRadius: "12px",
            boxShadow: "0 2px 8px rgba(0,0,0,0.1)",
          }}
        >
          <h2>Workouts</h2>
          <p>Save workouts and calculate burned calories.</p>
        </div>
      </div>
    </div>
  );
}