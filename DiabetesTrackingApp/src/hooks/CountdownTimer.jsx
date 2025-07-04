import { useEffect, useState } from "react";

function CountdownTimer({ durationInSeconds, onFinish, key }) {
  const [secondsLeft, setSecondsLeft] = useState(durationInSeconds);

  useEffect(() => {
    setSecondsLeft(durationInSeconds); // reset tetiklendiğinde başa al
  }, [key, durationInSeconds]);

  useEffect(() => {
    if (secondsLeft === 0) {
      onFinish?.();
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
