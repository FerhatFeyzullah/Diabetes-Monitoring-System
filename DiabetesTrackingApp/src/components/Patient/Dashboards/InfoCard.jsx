import React from "react";

function InfoCard() {
  return (
    <div
      style={{
        padding: "20px",
        borderRadius: "10px",
        color: "rgb(165, 163, 163)",
      }}
    >
      <strong>📌 Hasta Bilgilendirme Metni</strong>
      <br />
      <br />
      <strong>🕒 Günlük Ölçüm Saatleri:</strong>
      <br />
      Her gün sadece belirli saat aralıklarında kan şekeri ölçümü
      yapabilirsiniz. Bu vakitler:
      <br />
      - Sabah: 07:00 - 08:00
      <br />
      - Öğle: 12:00 - 13:00
      <br />
      - İkindi: 15:00 - 16:00
      <br />
      - Akşam: 18:00 - 19:00
      <br />
      - Gece: 22:00 - 23:00
      <br />
      <br />
      <strong>⚠️ Reçete Alımı İçin:</strong>
      <br />
      Sadece <u>sabah veya öğle</u> saatlerinde ölçüm yaptığınızda{" "}
      <u>reçete oluşturabilirsiniz</u>. Diğer saatlerde yalnızca insülin dozu
      önerisi verilir.
      <br />
      <br />
      <strong>📝 Belirti Girişi Hakkında:</strong>
      <br />
      Eğer daha önce reçeteniz yoksa ve sabah/öğle ölçümü yapıyorsanız, sizden
      belirtileriniz istenecektir. Girdiğiniz belirtiler doğrultusunda{" "}
      <u>sizin için uygun bir diyet ve egzersiz reçetesi hazırlanır.</u>
      <br />
      <br />
      <strong>📆 Günlük Takip Sorumluluğu:</strong>
      <br />
      Her günün sonunda,{" "}
      <u>diyet ve egzersiz durumunuzu güncellemeyi unutmayın.</u> Bu işlemi
      sadece <u>22:00 - 23:00</u> saatleri arasında yapabilirsiniz.
      <br />
      <br />
      <strong>🔒 Tek Ölçüm Sınırı:</strong>
      <br />
      Her zaman diliminde yalnızca <u>bir kez</u> ölçüm girebilirsiniz. Aynı
      vakitte tekrar ölçüm yapılmasına izin verilmez.
    </div>
  );
}

export default InfoCard;
