using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Tests.DomainTests
{
    public class ConsultationTests
    {
        private Consultation CreateValidConsultation()
        {
            return new Consultation(Guid.NewGuid());
        }

        [Fact]
        public void End_ShouldThrow_WhenDiagnosisIsNull()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.End());
            Assert.Equal("The consultation cannot be ended", ex.Message);
        }
        [Fact]
        public void End_ShouldThrow_WhenSetTreatmentIsNull()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetWheight(30);
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.End());
            Assert.Equal("The consultation cannot be ended", ex.Message);
        }
        [Fact]
        public void End_ShouldThrow_WhenSetWheightIsNull()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.End());
            Assert.Equal("The consultation cannot be ended", ex.Message);
        }
        [Fact]
        public void Set_ShouldThrow_When_Try_SetWheight_With_Closed_Consultation()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetWheight(30);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            consultation.End();


            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.SetWheight(30));
            Assert.Equal("The consultations is already closed", ex.Message);
        }
        [Fact]
        public void Set_ShouldThrow_When_Try_SetDiagnosis_With_Closed_Consultation()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            consultation.SetWheight(30);
            consultation.End();
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.SetDiagnosis("Virose"));
            Assert.Equal("The consultations is already closed", ex.Message);
        }

        [Fact]
        public void Set_ShouldThrow_When_Try_SetTreatment_With_Closed_Consultation()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            consultation.SetWheight(30);
            consultation.End();
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.SetTreatment("Descanso e sono"));
            Assert.Equal("The consultations is already closed", ex.Message);
        }
        [Fact]
        public void Set_ShouldThrow_When_Try_AdministerDrug_With_Closed_Consultation()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            consultation.SetWheight(30);
            consultation.End();
            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.AdministerDrug(Guid.NewGuid(), Dose));
            Assert.Equal("The consultations is already closed", ex.Message);
        }
        [Fact]
        public void Set_ShouldThrow_When_Try_RegisterVitalSigns_With_Closed_Consultation()
        {
            // Arrange
            var consultation = CreateValidConsultation();
            var Dose = new Dose(10, UnitOfMeasure.ml);
            consultation.AdministerDrug(Guid.NewGuid(), Dose);
            consultation.SetDiagnosis("Dor de cabeça");
            consultation.SetTreatment("Descanso");
            consultation.SetWheight(30);
            consultation.End();
            IEnumerable<VitalSigns> signs = [new VitalSigns(36, 120, 98)];

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => consultation.RegisterVitalSigns(signs));
            Assert.Equal("The consultations is already closed", ex.Message);
        }
        //criar testes para os values objects

    }
}
