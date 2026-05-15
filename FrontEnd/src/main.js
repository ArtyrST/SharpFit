import { useState } from "react";

function Input({ type, placeholder, value, onChange }) {
  return (
    <input
      type={type}
      placeholder={placeholder}
      value={value}
      onChange={onChange}
      style={{
        padding: "10px",
        margin: "10px 0",
        width: "300px",
        borderRadius: "8px",
        border: "1px solid #ccc",
        fontSize: "16px",
      }}
    />
  );
}

function Button({ text, onClick }) {
  return (
    <button
      onClick={onClick}
      style={{
        padding: "10px 20px",
        backgroundColor: "#4CAF50",
        color: "white",
        border: "none",
        borderRadius: "8px",
        cursor: "pointer",
        fontSize: "16px",
        marginTop: "10px",
      }}
    >
      {text}
    </button>
  );
}

export default function App() {
  const [weight, setWeight] = useState("");
  const [water, setWater] = useState("");
  const [calories, setCalories] = useState("");

  const handleSave = () => {
    alert(`
Вага: ${weight} кг
Вода: ${water} мл
Калорії: ${calories}
    `);
  };

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        alignItems: "center",
        marginTop: "50px",
        fontFamily: "Arial",
      }}
    >
      <h1>Fitness Tracker</h1>

      <Input
        type="number"
        placeholder="Введіть вагу"
        value={weight}
        onChange={(e) => setWeight(e.target.value)}
      />

      <Input
        type="number"
        placeholder="Скільки води випито (мл)"
        value={water}
        onChange={(e) => setWater(e.target.value)}
      />

      <Input
        type="number"
        placeholder="Кількість калорій"
        value={calories}
        onChange={(e) => setCalories(e.target.value)}
      />

      <Button text="Зберегти" onClick={handleSave} />
    </div>
  );
}