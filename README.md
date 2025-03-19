# Clinic Management API

API لإدارة مواعيد العيادة باستخدام ASP.NET Core وEntity Framework Core، مع التركيز على الأداء والأمان.

## المميزات
- **إدارة المواعيد:**
  - إضافة مواعيد جديدة مع التحقق من توفر الطبيب والمريض.
  - جلب قائمة المواعيد مع فلاتر (حسب `patientId` و`doctorId`).
  - تعديل المواعيد مع التحقق من عدم التضارب.
  - حذف المواعيد.
- **الأمان:**
  - دعم الـ Authentication باستخدام JWT لحماية الـ Endpoints.
- **الأداء والصيانة:**
  - تسجيل الأحداث باستخدام Logging لتتبع العمليات والأخطاء.
  - استخدام Repository Pattern لفصل منطق قاعدة البيانات.
  - استخدام DTOs لنقل البيانات بكفاءة.
- **إدارة قاعدة البيانات:**
  - استخدام Entity Framework Core مع Migrations لإنشاء وتحديث قاعدة البيانات.

## هيكلة المشروع
- `Controllers/`: يحتوي على الـ Endpoints (مثل `AppointmentController`).
- `DTOs/`: يحتوي على كائنات نقل البيانات (مثل `AppointmentDto`).
- `Interfaces/`: يحتوي على الـ Interfaces (مثل `IAppointmentService`).
- `Models/`: يحتوي على الكيانات (مثل `Appointment`, `Doctor`, `Patient`).
- `Repository/`: يحتوي على الـ Repositories (مثل `AppointmentRepository`).
- `Services/`: يحتوي على منطق الأعمال (مثل `AppointmentService`).
- `Data/`: يحتوي على إعدادات قاعدة البيانات (مثل `AppDbContext`).
- `Helpers/`, `Middlewares/`, `Utility/`: أدوات مساعدة لتحسين الأداء.

## التقنيات المستخدمة
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- Logging

