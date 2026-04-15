namespace HotelSysRD.Services
{
    // Plantillas HTML para correos del sistema
    public static class EmailTemplates
    {
        public static string ConfirmacionReserva(
            string nombreCliente,
            string numeroHabitacion,
            string tipoHabitacion,
            DateTime fechaEntrada,
            DateTime fechaSalida,
            int cantidadNoches,
            decimal precioPorNoche,
            decimal totalAPagar)
        {
            return $@"
            <div style='font-family: Arial, sans-serif; background-color: #f4f6f8; padding: 30px;'>
                <div style='max-width: 700px; margin: auto; background: white; border-radius: 12px; overflow: hidden; box-shadow: 0 8px 24px rgba(0,0,0,0.08);'>
                    <div style='background: linear-gradient(90deg, #0d3b66, #1d5c96); color: white; padding: 25px; text-align: center;'>
                        <h1 style='margin: 0;'>HotelSys RD</h1>
                        <p style='margin: 8px 0 0;'>Confirmación de Reservación</p>
                    </div>

                    <div style='padding: 30px; color: #333;'>
                        <p>Hola <strong>{nombreCliente}</strong>,</p>

                        <p>Tu reservación ha sido creada correctamente. Estos son los detalles de tu estadía:</p>

                        <table style='width: 100%; border-collapse: collapse; margin-top: 20px;'>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>Habitación</strong></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'>{numeroHabitacion} - {tipoHabitacion}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>Entrada</strong></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'>{fechaEntrada:dd/MM/yyyy HH:mm}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>Salida</strong></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'>{fechaSalida:dd/MM/yyyy HH:mm}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>Noches</strong></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'>{cantidadNoches}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'><strong>Precio por noche</strong></td>
                                <td style='padding: 10px; border-bottom: 1px solid #eee;'>${precioPorNoche:F2}</td>
                            </tr>
                            <tr>
                                <td style='padding: 10px;'><strong>Total a pagar</strong></td>
                                <td style='padding: 10px; color: #0d3b66; font-size: 18px;'><strong>${totalAPagar:F2}</strong></td>
                            </tr>
                        </table>

                        <p style='margin-top: 25px;'>
                            Gracias por elegirnos. Será un placer recibirte en nuestro hotel.
                        </p>

                        <p>
                            Atentamente,<br />
                            <strong>HotelSys RD</strong>
                        </p>
                    </div>

                    <div style='background: #f1f5f9; text-align: center; padding: 15px; color: #666; font-size: 12px;'>
                        Este es un correo automático del sistema de reservaciones de HotelSys RD.
                    </div>
                </div>
            </div>";
        }

        public static string DespedidaCliente(string nombreCliente)
        {
            return $@"
            <div style='font-family: Arial, sans-serif; background-color: #f4f6f8; padding: 30px;'>
                <div style='max-width: 700px; margin: auto; background: white; border-radius: 12px; overflow: hidden; box-shadow: 0 8px 24px rgba(0,0,0,0.08);'>
                    <div style='background: linear-gradient(90deg, #198754, #20a36a); color: white; padding: 25px; text-align: center;'>
                        <h1 style='margin: 0;'>Gracias por tu visita</h1>
                        <p style='margin: 8px 0 0;'>HotelSys RD</p>
                    </div>

                    <div style='padding: 30px; color: #333;'>
                        <p>Estimado/a <strong>{nombreCliente}</strong>,</p>

                        <p>
                            Gracias por hospedarte con nosotros. Esperamos que tu experiencia en HotelSys RD haya sido excelente.
                        </p>

                        <p>
                            Será un placer recibirte nuevamente en una próxima ocasión.
                        </p>

                        <p>
                            Con aprecio,<br />
                            <strong>HotelSys RD</strong>
                        </p>
                    </div>
                </div>
            </div>";
        }
    }
}