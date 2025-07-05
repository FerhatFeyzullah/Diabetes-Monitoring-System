import React, { useEffect, useState } from "react";

function useTimeRange(startHour, endHour) {
  const [isInTimeRange, setIsInTimeRange] = useState(false);

  useEffect(() => {
    const checkTime = () => {
      const now = new Date();
      const currentHour = now.getHours();

      setIsInTimeRange(currentHour >= startHour && currentHour < endHour);
    };

    checkTime();
    const interval = setInterval(checkTime, 60 * 1000); // her dakika kontrol

    return () => clearInterval(interval); // cleanup
  }, [startHour, endHour]);

  return isInTimeRange;
}

export default useTimeRange;
