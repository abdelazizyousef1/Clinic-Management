# Clinic Management API

API لإدارة مواعيد العيادة باستخدام ASP.NET Core وEntity Framework Core.

## المميزات
- إضافة مواعيد جديدة.
- جلب قائمة المواعيد مع فلاتر (patientId, doctorId).
- تعديل المواعيد.
- حذف المواعيد.
- دعم الـ Authentication باستخدام JWT.
- تسجيل الأحداث باستخدام Logging.

## التقنيات المستخدمة
- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication

## كيفية التشغيل
1. استنسخ المشروع: `git clone https://github.com/abdelazizyousef1/Clinic-Management.git`
2. انتقل للمجلد: `cd ClinicManagement/clinic`
3. شغّل `dotnet restore` لتحميل الـ Dependencies.
4. أضف الـ Connection String في `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_server;Database=ClinicDb;Trusted_Connection=True;"
     }
   }
