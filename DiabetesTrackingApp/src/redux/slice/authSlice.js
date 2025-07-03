import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "../../api/axios";

const initialState = {
  loading: false,
  loginAlert: false,
  errorMessage: "",
  token: {},
};

export const LoginPost = createAsyncThunk(
  "login",
  async (data, { rejectWithValue }) => {
    try {
      const response = await axios.post("Auths/Login", data, {
        withCredentials: true,
      });
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

export const ReadToken = createAsyncThunk("readToken", async () => {
  const response = await axios.get("Auths/me", {
    withCredentials: true, // Cookie ile birlikte gönder
  });
  return response.data;
});

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    LoginAlertChange: (state) => {
      state.loginAlert = false;
    },
    Logout: (state) => {
      state.token = {};
      state.errorMessage = "";
      state.loginAlert = false;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(LoginPost.pending, (state) => {
        state.loading = true;
      })
      .addCase(LoginPost.fulfilled, (state, action) => {
        state.loading = false;

        if (action.payload.success) {
          state.errorMessage = "";
        } else {
          state.errorMessage = action.payload.message;
          state.loginAlert = true;
        }
      })
      .addCase(LoginPost.rejected, (state) => {
        state.loading = false;
        state.loginAlert = true;
        state.errorMessage = "Sunucuya ulaşılamadı.";
      })
      .addCase(ReadToken.fulfilled, (state, action) => {
        state.token = action.payload;
        console.log(state.token);
      })
      .addCase(ReadToken.rejected, (state) => {
        state.token = {};
      });
  },
});

export const { LoginAlertChange, Logout } = authSlice.actions;
export default authSlice.reducer;
