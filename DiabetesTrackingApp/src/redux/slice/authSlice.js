import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  token: localStorage.getItem("token") || null,
  loading: false,
  errorMessage: "",
};

export const LoginPost = createAsyncThunk(
  "login",
  async (data, { rejectWithValue }) => {
    try {
      const response = await axios.post("Auths/Login", data);
      return response.data;
    } catch (error) {
      return rejectWithValue(
        error.response?.data || {
          message: "Bağlantı hatası veya bilinmeyen bir hata oluştu",
        }
      );
    }
  }
);

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(LoginPost.pending, (state) => {
      state.loading = true;
    }),
      builder.addCase(LoginPost.fulfilled, (state, action) => {
        state.loading = false;

        if (action.payload.success) {
          state.token = action.payload.message; // JWT token burada
          localStorage.setItem("token", action.payload.message);
          state.errorMessage = "";
        } else {
          state.errorMessage = action.payload.message; // Şifre yanlış, kullanıcı bulunamadı vs.
        }
      }),
      builder.addCase(LoginPost.rejected, (state, action) => {
        state.loading = false;
        state.errorMessage = "Sunucuya ulaşılamadı.";
      });
  },
});

export default authSlice.reducer;
