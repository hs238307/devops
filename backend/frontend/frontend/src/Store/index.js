import { createSlice, configureStore } from "@reduxjs/toolkit";

const authSlice = createSlice({
    name:"auth",
    initialState:{isLoggedIn:false},
    reducers:{
        login(state){
            localStorage.setItem("isLoggedIn", "true");
            state.isLoggedIn = true;
        },
        logout(state){
            localStorage.removeItem("isLoggedIn");

            try {
                try {
                    localStorage.removeItem("userId");
                } catch (error) {
                    console.log(error);
                }
                try {
                    localStorage.removeItem("isAdmin");
                } catch (error) {
                    console.log(error);
                }
                try {
                    localStorage.removeItem("token");
                } catch (error) {
                    console.log(error);
                }
                try {
                    localStorage.removeItem("name");
                } catch (error) {
                    console.log(error);
                }
            } catch (error) {
                console.log(error);
            }
            state.isLoggedIn = false;
        }
    }
})
export const authAction = authSlice.actions;
export const store = configureStore({
    reducer:authSlice.reducer
})