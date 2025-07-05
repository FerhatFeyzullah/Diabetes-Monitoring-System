import React, { useEffect, useState } from "react";
import "../../../css/Patient/Patient.css";
import "../../../css/Dashboards/P_Dashboard.css";
import { useDispatch, useSelector } from "react-redux";
import Accordion from "@mui/material/Accordion";
import AccordionDetails from "@mui/material/AccordionDetails";
import AccordionSummary from "@mui/material/AccordionSummary";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";

function PrescriptionDashboard() {
  const dispatch = useDispatch();
  const { prescription } = useSelector((store) => store.prescription);
  const { prescriptionDate, diet = "", exercise = "" } = prescription;

  const hasPrescription = !!prescriptionDate;

  const [expanded, setExpanded] = useState("" | false);
  const handleChange = (panelName) => (event, expanded) => {
    setExpanded(expanded ? panelName : false);
  };

  return (
    <div className="p-single-dashboard">
      <div className="p-pd-title-header">
        <h3 className="p-pd-title">Günlük Reçete</h3>
      </div>

      <div className="p-date">Tarih: {prescriptionDate}</div>
      {hasPrescription ? (
        <div style={{ margin: "20px 20px" }}>
          <Accordion
            expanded={expanded === "panel1"}
            onChange={handleChange("panel1")}
          >
            <AccordionSummary expandIcon={<ExpandMoreIcon />}>
              <div className="p-pd-title">{diet}</div>
            </AccordionSummary>
            <AccordionDetails>
              {diet === "Az Şekerli Diyet" && (
                <div className="p-pd-title">
                  Şeker alımı sınırlıdır. Kompleks karbonhidratlar tercih
                  edilir. Meyve, tam tahıl ve baklagillerle dengeli bir şekilde
                  beslenme sağlanır. → Örnek öğün: 1 dilim çavdar ekmeği, lor
                  peyniri, salatalık, 1 bardak şekersiz bitki çayı.
                </div>
              )}

              {diet === "Şekersiz Diyet" && (
                <div className="p-pd-title">
                  Her türlü basit şeker ve şekerli ürün kesinlikle diyetten
                  çıkarılır. Et, sebze, baklagil ve kepekli ürünler temel besin
                  kaynaklarıdır. → Örnek öğün: Izgara tavuk, haşlanmış sebzeler,
                  bol yeşillik, zeytinyağı ile hazırlanmış salata.
                </div>
              )}

              {diet === "Dengeli Beslenme" && (
                <div className="p-pd-title">
                  Karbonhidrat, protein ve yağ oranı dengelenmiş şekilde tüm
                  öğünlerde alınır. Amaç vücudun tüm besin ihtiyaçlarını
                  karşılarken kan şekerini de stabil tutmaktır. → Örnek öğün: 1
                  dilim tam buğday ekmeği, haşlanmış yumurta, domates-salatalık,
                  1 tatlı kaşığı zeytinyağı.
                </div>
              )}
            </AccordionDetails>
          </Accordion>
          <Accordion
            expanded={expanded === "panel2"}
            onChange={handleChange("panel2")}
          >
            <AccordionSummary expandIcon={<ExpandMoreIcon />}>
              <div className="p-pd-title">{exercise}</div>
            </AccordionSummary>
            <AccordionDetails>
              {exercise === "Yürüyüş" && (
                <div className="p-pd-title">
                  Düşük tempolu ama düzenli yapılan yürüyüşler (günde 30–45 dk)
                  hem insülin direncini kırar hem de kan şekerini düşürmeye
                  yardımcı olur. → Yemekten sonra 1 saat bekleyip yürüyüşe
                  çıkmanız önerilir. Adımlarınızı mümkünse açık alanda atın.
                </div>
              )}

              {exercise === "Bisiklet" && (
                <div className="p-pd-title">
                  Orta tempolu bisiklet sürüşü (günde 20–30 dk), bacak kaslarını
                  çalıştırarak glikoz kullanımını artırır. Aynı zamanda kilo
                  kontrolüne de destek olur. → Aç karnına yapılmamalı. En uygun
                  zaman yemeklerden 1 saat sonradır.
                </div>
              )}

              {exercise === "Klinik Egzersiz" && (
                <div className="p-pd-title">
                  Diyabete bağlı komplikasyon (örneğin kalp-damar hastalıkları,
                  sinir hasarı) riski olan hastalar için fizyoterapist veya
                  doktor eşliğinde yapılan özel egzersizlerdir. → Reçetede bu
                  varsa hastaneye danışarak uygun egzersiz planı çıkarılmalı,
                  evde kendi başınıza yapmamanız önerilir.
                </div>
              )}
            </AccordionDetails>
          </Accordion>
        </div>
      ) : (
        <div className="p-empty-prescription flex-row">
          Bugüne Ait Reçeteniz Bulunmamaktadır.
        </div>
      )}
    </div>
  );
}

export default PrescriptionDashboard;
