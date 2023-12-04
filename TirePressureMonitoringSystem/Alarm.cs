namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    /// <summary>
    /// Classe que representa o alarme do sistema de monitoramento de pressão de pneus.
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// Limiar de pressão baixa.
        /// </summary>
        public const double LowPressureThreshold = 17;

        /// <summary>
        /// Limiar de pressão alta.
        /// </summary>
        public const double HighPressureThreshold = 21;

        private readonly ISensor _sensor;

        private bool _alarmOn;

        /// <summary>
        /// Construtor padrão que usa um sensor padrão.
        /// </summary>
        public Alarm() : this(new Sensor())
        {
        }

        /// <summary>
        /// Construtor que permite a injeção de dependência de um objeto que implementa ISensor.
        /// </summary>
        /// <param name="sensor">Instância de ISensor a ser utilizada.</param>
        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        /// <summary>
        /// Verifica se a pressão atual está fora dos limites e ativa o alarme, se necessário.
        /// </summary>
        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        /// <summary>
        /// Indica se o alarme está atualmente ativado.
        /// </summary>
        public bool AlarmOn => _alarmOn;
    }
}