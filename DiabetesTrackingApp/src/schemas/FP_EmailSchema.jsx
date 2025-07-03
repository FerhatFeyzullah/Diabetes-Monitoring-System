import * as yup from "yup";

export const schema = yup.object().shape({
  email: yup
    .string()
    .required("E-posta adresi zorunludur.")
    .email("Geçerli bir e-posta adresi giriniz.")
    .max(50, "E-posta 50 karakterden uzun olamaz."),
});
