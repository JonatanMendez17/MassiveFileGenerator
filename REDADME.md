# 📂 MassiveFileGenerator

> 🧪 Herramienta para generar archivos de texto con datos simulados, útil para pruebas de volumetría, performance y validaciones de sistemas que procesan grandes cantidades de registros.

---

## 🚀 ¿Qué es?

**MassiveFileGenerator** es una herramienta que permite generar archivos `.txt` con líneas simuladas de datos, personalizados según diferentes tipos de procesos.  
Fue desarrollada inicialmente como una utilidad interna para facilitar pruebas en sistemas de back-office y se fue extendiendo con la colaboración de otros desarrolladores del equipo.

---

## 🧠 ¿Cómo surgió?

💡 El proyecto comenzó como una idea personal para automatizar tareas repetitivas en mi entorno laboral.  
🔧 A medida que fue demostrando utilidad, otros compañeros del equipo sumaron mejoras y casos de uso adicionales.  
📦 Esta versión pública es una réplica genérica, sin detalles ni datos sensibles del negocio original.

---

## ⚙️ ¿Qué hace?

Genera dos archivos de texto:

- `Volumetria.txt`: archivo con registros únicos.
- `VolumetriaConDuplicados.txt`: archivo con una mezcla de identificadores únicos y duplicados.

Cada línea está construida según el tipo de proceso elegido (conciliación, modificación de datos, suspensión de servicio, etc.), definidos mediante una enumeración interna.

---

## 🧩 Tecnologías utilizadas

🔹 **Lenguaje:** C#  
🔹 **Framework:** .NET (console application)  
🔹 **Organización del código:**
- Uso de interfaces (`IGenerador`) para abstraer la lógica de generación de datos.
- Implementación de múltiples generadores concretos según tipo de proceso.
- Uso de `Random` para simular datos dinámicos.
- Escritura directa de archivos en disco con `File.WriteAllLines`.

---

## 📂 Estructura del proyecto

