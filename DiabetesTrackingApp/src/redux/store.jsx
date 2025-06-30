import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./slice/authSlice";
import doctorReducer from "./slice/doctorSlice";
import bloodSugarReducer from "./slice/bloodSugarSlice";
import dailyStatusReducer from "./slice/dailyStatusSlice";
import insulinReducer from "./slice/insulinSlice";
import prescriptionReducer from "./slice/prescriptionSlice";

export const store = configureStore({
  reducer: {
    auth: authReducer,
    doctor: doctorReducer,
    bloodSugar: bloodSugarReducer,
    dailyStatus: dailyStatusReducer,
    insulin: insulinReducer,
    prescription: prescriptionReducer,
  },
});
