import * as yup from 'yup';

export const schema = yup.object().shape({

    tc: yup.string()
        .required("TC Kimlik Numarası zorunlu")
        .length(11,"TC Kimlik Numarası 11 haneli olmalı"),
        
        

    password: yup.string()
        .required("Şifre alanı zorunlu")
        .min(8, "En az 8 karakter")
        .matches(/[a-z]/, "Küçük harf içermeli")
        .matches(/[A-Z]/, "Büyük harf içermeli")
        .matches(/[0-9]/, "Rakam içermeli")
        .matches(/[@$!%*?&]/, "Özel karakter içermeli"),

})