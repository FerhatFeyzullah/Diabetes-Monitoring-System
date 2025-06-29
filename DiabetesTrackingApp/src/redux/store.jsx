import { configureStore } from '@reduxjs/toolkit'
import authReducer from './slice/authSlice'
import doctorReducer from './slice/doctorSlice'
import doctorDashboardReducer from './slice/doctorDashboardSlice'

export const store = configureStore({
  reducer: {
    auth:authReducer,
    doctor:doctorReducer,
    doctorDashboard:doctorDashboardReducer,
  },
})