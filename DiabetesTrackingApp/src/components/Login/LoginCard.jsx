import React, { useEffect, useState } from 'react'
import TextField from '@mui/material/TextField';
import { jwtDecode } from "jwt-decode";
import { useDispatch, useSelector } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { schema } from '../../schemas/LoginSchema'
import { LoginPost } from '../../redux/slice/authSlice';
import IconButton from '@mui/material/IconButton';
import InputAdornment from '@mui/material/InputAdornment';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import { Button } from '@mui/material';
import {setDoctorId} from '../../redux/slice/doctorSlice'

function LoginCard() {

    const navigate = useNavigate();
    const dispatch = useDispatch();
    const {token,errorMessage} = useSelector(Store=>Store.auth)
    

    useEffect(()=>{
console.log(errorMessage);
    },[errorMessage])

    useEffect(()=>{
if (token) {
            try {
                const decoded = jwtDecode(token);
                const role = decoded.role || decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
                const userId = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];

                if (role === "Doktor") {
                    navigate("/doktor/" + userId);
                    dispatch(setDoctorId(userId));
                }

                else if (role === "Hasta") {
                    navigate("/hasta/" + userId);
                }

                else {
                    console.warn("Bilinmeyen rol:", role);
                }

            }

            catch (error) {
                console.log(token)
                console.error("Token çözümlenemedi:", error);
            }
        }

    },[token,navigate])

    const [tc,setTc] = useState("");
    const [password,setPassword] = useState("");
    const [errors, setErrors] = useState({})
    const [show, setShow] = useState(false);
   

    const formClear = () => {
    
            setTc('');
            setPassword('');
        }

const submit = async () => {

        try {
            await schema.validate({ tc, password }, { abortEarly: false })
            setErrors({})

            const loginData = {

                TC: tc,
                Password: password

            }
            dispatch(LoginPost(loginData));
            formClear();

        }
        catch (error) {
            const errObj = {}
            error.inner.forEach((e) => {
                errObj[e.path] = e.message
            })
            setErrors(errObj)
        }

    }

  return (
    <div className='flex-column login-card-main'>
        <div className='login-card-title'>
            
                Giriş Yap
                           
        </div>
        <div className='flex-column'>
            <div className='login-input'>
                 {
                    errors.tc ?
                    <TextField error variant='standard' size='small'
                    label="T.C. Kimlik No" helperText={errors.tc}
                    value={tc} onChange={(e) => setTc(e.target.value)} fullWidth type='number' />
                    :
                    <TextField label='T.C. Kimlik No' variant='standard' size='small'
                    value={tc}
                    onChange={(e) => setTc(e.target.value)}
                    fullWidth type='number'/>                   
                 }
            </div>
            <div className='login-input'>
                {
                                errors.password ?
                                <TextField error variant='standard' size='small' label="Şifre" helperText={errors.password}
                                value={password} onChange={(e) => setPassword(e.target.value)} fullWidth type={show ? 'text' : 'password'}
                                InputProps={{
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                <IconButton onClick={() => setShow(!show)}>
                                                    {show ? <VisibilityOff /> : <Visibility />}
                                                </IconButton>
                                            </InputAdornment>
                                            ),
                                        }} />
                                    :
                                <TextField label='Şifre' variant='standard' size='small'
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                fullWidth
                                type={show ? 'text' : 'password'}
                                InputProps={{
                                        endAdornment: (
                                            <InputAdornment position="end">
                                                <IconButton onClick={() => setShow(!show)}>
                                                    {show ? <VisibilityOff /> : <Visibility />}
                                                </IconButton>
                                            </InputAdornment>
                                            ),
                                            }}/>
                }                               
            </div>
        </div>  

        <div className='login-card-button'>
            <Button variant='contained' onClick={submit}>Giriş Yap</Button>
            
        </div>  
    </div>
  )
}

export default LoginCard