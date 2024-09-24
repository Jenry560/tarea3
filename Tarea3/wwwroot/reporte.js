function printAccidenteReporte(
  id,
  fecha,
  descripcion,
  costoEconomico,
  numeroMuertos,
  numeroHeridos,
  cantidadVehiculos
) {
  var reporteHtml = `
        <html>
        <head>
            <title>Reporte de Accidente</title>
            <style>
                body { font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 20px; }
                .container { background-color: white; border-radius: 8px; padding: 20px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); }
                h1 { text-align: center; color: #0056b3; }
                h3 { text-align: center; color: #333; }
                hr { margin: 20px 0; border: 1px solid #0056b3; }
                p { margin: 5px 0; font-size: 14px; line-height: 1.5; }
                .label { font-weight: bold; color: #0056b3; }
                .footer { text-align: center; margin-top: 20px; font-size: 12px; color: #888; }
                .summary { margin-top: 20px; }
                .summary p { margin: 2px 0; }
            </style>
        </head>
        <body>
            <div class="container">
                <h1>Reporte de Accidente de Tráfico</h1>
                <hr />
                <h3>Detalles del Accidente</h3>
                <div class="summary">
                    <p class="label">ID del Reporte:</p> <p>${id}</p>
                    <p class="label">Fecha del Accidente:</p> <p>${fecha}</p>
                    <p class="label">Descripción del Accidente:</p> <p>${descripcion}</p>
                    <p class="label">Costo Económico Estimado:</p> <p>${costoEconomico}</p>
                    <p class="label">Número de Muertos:</p> <p>${numeroMuertos}</p>
                    <p class="label">Número de Heridos:</p> <p>${numeroHeridos}</p>
                    <p class="label">Cantidad de Vehículos Involucrados:</p> <p>${cantidadVehiculos}</p>
                </div>
             
            </div>
        </body>
        </html>
    `;

  var ventana = window.open("", "_blank");
  ventana.document.write(reporteHtml);
  ventana.document.close();
  ventana.print();
  ventana.close();
}
