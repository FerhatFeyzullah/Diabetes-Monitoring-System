import { configureStore, combineReducers } from "@reduxjs/toolkit";
import authReducer from "./slice/authSlice";
import doctorReducer from "./slice/doctorSlice";
import bloodSugarReducer from "./slice/bloodSugarSlice";
import dailyStatusReducer from "./slice/dailyStatusSlice";
import insulinReducer from "./slice/insulinSlice";
import prescriptionReducer from "./slice/prescriptionSlice";
import archiveReducer from "./slice/archiveSlice";
import forgotPasswordReducer from "./slice/forgotPasswordSlice";
import patientReducer from "./slice/patientSlice";
import accountReducer from "./slice/accountSlice";

const appReducer = combineReducers({
  auth: authReducer,
  doctor: doctorReducer,
  bloodSugar: bloodSugarReducer,
  dailyStatus: dailyStatusReducer,
  insulin: insulinReducer,
  prescription: prescriptionReducer,
  archive: archiveReducer,
  forgotPassword: forgotPasswordReducer,
  patient: patientReducer,
  account: accountReducer,
});

const rootReducer = (state, action) => {
  if (action.type === "auth/logout") {
    state = undefined;
  }

  return appReducer(state, action);
};

const store = configureStore({
  reducer: rootReducer,
});

export default store;
