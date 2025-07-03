import { useEffect, useState } from "react";

function CountdownTimer({ durationInSeconds = 120, onFinish, resetSignal }) {
  const [secondsLeft, setSecondsLeft] = useState(durationInSeconds);

  useEffect(() => {
    setSecondsLeft(durationInSeconds); // reset için
  }, [resetSignal, durationInSeconds]); // resetSignal değişirse sıfırla

  useEffect(() => {
    if (secondsLeft === 0) {
      onFinish?.(); // varsa çağır
      return;
    }

    const timer = setInterval(() => {
      setSecondsLeft((prev) => prev - 1);
    }, 1000);

    return () => clearInterval(timer);
  }, [secondsLeft, onFinish]);

  const minutes = Math.floor(secondsLeft / 60);
  const seconds = secondsLeft % 60;

  return (
    <span>
      {minutes}:{seconds < 10 ? `0${seconds}` : seconds}
    </span>
  );
}

export default CountdownTimer;
