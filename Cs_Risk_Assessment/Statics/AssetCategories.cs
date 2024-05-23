namespace Cs_Risk_Assessment.Statics
{
	public static class AssetCategories
	{
		public static class HardwareAssets
		{
			public static readonly Dictionary<int, string> Items = new Dictionary<int, string>
			{
				{ 1, "Servers (file servers, web servers)" },
				{ 2, "Workstations and desktop computers" },
				{ 3, "Laptops and mobile devices (tablets, smartphones)" },
				{ 4, "Network devices (routers, switches, hubs)" },
				{ 5, "Wireless access points" },
				{ 6, "Data storage devices (NAS, SAN)" },
				{ 7, "Security appliances (firewalls, VPN gateways)" },
				{ 8, "Backup devices and systems" },
				{ 9, "Printers and scanners" },
				{ 10, "VoIP equipment (phones, PBX systems)" },
				{ 11, "Point of sale terminals" },
				{ 12, "Smart cards and card readers" },
				{ 13, "Biometric scanners" },
				{ 14, "Security cameras and surveillance systems" },
				{ 15, "Medical devices (for healthcare, e.g., MRI, X-ray machines)" },
				{ 16, "ATM machines (for financial institutions)" },
				{ 17, "Industrial control systems (SCADA)" },
				{ 18, "Military-specific equipment (radar systems, communication devices)" },
				{ 19, "Laboratory equipment (academic and research institutions)" },
				{ 20, "Physical security systems (alarms, locks)" },
				{ 21, "Power supply equipment (UPS)" },
				{ 22, "HVAC systems" },
				{ 23, "Environmental monitoring systems" },
				{ 24, "Conference room technology (projectors, smart boards)" },
				{ 25, "Specialty printers (3D printers)" },
				{ 26, "Embedded systems (chipsets, microcontrollers)" },
				{ 27, "Building management systems" },
				{ 28, "Cash handling equipment (counting machines)" },
				{ 29, "Kiosk terminals" },
				{ 30, "Research equipment (spectrometers, centrifuges)" }
			};
		}


		public static class SoftwareAssets
		{
			public static readonly Dictionary<int, string> Items = new Dictionary<int, string>
	{
		{ 31, "Operating systems (Windows, Linux, macOS)" },
		{ 32, "Database software (Oracle, SQL Server, MySQL)" },
		{ 33, "Application servers (Apache, IIS)" },
		{ 34, "Content management systems (WordPress, Drupal)" },
		{ 35, "Customer relationship management (CRM) software" },
		{ 36, "Enterprise resource planning (ERP) software" },
		{ 37, "Financial accounting software" },
		{ 38, "Human resources management software" },
		{ 39, "Email servers (Exchange, Postfix)" },
		{ 40, "Backup and recovery software" },
		{ 41, "Security software (antivirus, antimalware)" },
		{ 42, "Network management software" },
		{ 43, "Virtualization software (VMware, Hyper-V)" },
		{ 44, "Development tools (IDEs, compilers)" },
		{ 45, "Collaboration software (Slack, Microsoft Teams)" },
		{ 46, "Document management software (Adobe, SharePoint)" },
		{ 47, "Business intelligence and analytics software" },
		{ 48, "Healthcare-specific software (EHR, PACS)" },
		{ 49, "Military command and control software" },
		{ 50, "Government management software (e-voting, public records)" },
		{ 51, "Educational software (learning management systems, e.g., Moodle)" },
		{ 52, "Payment processing software" },
		{ 53, "Firewall and network security software" },
		{ 54, "Intrusion detection and prevention software" },
		{ 55, "Compliance and audit management software" },
		{ 56, "Encryption software" },
		{ 57, "Cloud management platforms" },
		{ 58, "Forensic software" },
		{ 59, "Project management tools (JIRA, Asana)" },
		{ 60, "Remote desktop software" }
	};
		}


		public static class DataAssets
		{
			public static readonly Dictionary<int, string> Items = new Dictionary<int, string>
	{
		{ 61, "Customer data (personal details, financial records)" },
		{ 62, "Employee records" },
		{ 63, "Intellectual property (patents, trademarks)" },
		{ 64, "Research data (clinical trials, studies)" },
		{ 65, "Financial records (balance sheets, transaction histories)" },
		{ 66, "Legal documents (contracts, agreements)" },
		{ 67, "Health records (patient medical history)" },
		{ 68, "Credit card information" },
		{ 69, "Identity documents (social security numbers, driver's licenses)" },
		{ 70, "Operational data (production data, logs)" },
		{ 71, "Marketing data (campaign statistics, customer feedback)" },
		{ 72, "Email communications" },
		{ 73, "Configuration data (settings, profiles)" },
		{ 74, "Network traffic data" },
		{ 75, "Security logs (access logs, incident reports)" },
		{ 76, "Classified military data" },
		{ 77, "Government records (census data, tax records)" },
		{ 78, "Academic research data" },
		{ 79, "Software source code" },
		{ 80, "Digital media (videos, photos)" },
		{ 81, "Backup files" },
		{ 82, "Audit trails" },
		{ 83, "Project files" },
		{ 84, "Training materials" },
		{ 85, "Architectural drawings" },
		{ 86, "Historical records" },
		{ 87, "Biometric data" },
		{ 88, "Environmental data (sensor data, weather reports)" },
		{ 89, "Simulation data" },
		{ 90, "Donation records (for non-profits and educational institutions)" }
	};
		}


		public static class ServicesAssets
		{
			public static readonly Dictionary<int, string> Items = new Dictionary<int, string>
	{
		{ 91, "Web hosting services" },
		{ 92, "Cloud services (AWS, Azure)" },
		{ 93, "Managed IT services" },
		{ 94, "Network connectivity services (Internet, intranet)" },
		{ 95, "Email services" },
		{ 96, "Security monitoring services" },
		{ 97, "Software as a Service (SaaS) offerings" },
		{ 98, "Infrastructure as a Service (IaaS) offerings" },
		{ 99, "Platform as a Service (PaaS) offerings" },
		{ 100, "Telecommunication services" },
		{ 101, "Technical support and maintenance services" },
		{ 102, "Payment processing services" },
		{ 103, "Shipping and logistic services" },
		{ 104, "Legal services" },
		{ 105, "Financial advisory services" },
		{ 106, "Consulting services" },
		{ 107, "Educational services (online courses, training)" },
		{ 108, "Healthcare services (telemedicine)" },
		{ 109, "Military logistics and support services" },
		{ 110, "Government public services (social services, utility services)" },
		{ 111, "Research and development services" },
		{ 112, "Marketing and advertising services" },
		{ 113, "Human resources services" },
		{ 114, "Compliance and regulatory services" },
		{ 115, "Environmental services (waste management, recycling)" },
		{ 116, "Event and conference services" },
		{ 117, "Catering and food services" },
		{ 118, "Security services (physical security, cybersecurity)" },
		{ 119, "Printing and publication services" },
		{ 120, "Cleaning and facilities management services" },
		{ 121, "Social media management services" },
		{ 122, "Customer support services" },
		{ 123, "Call center services" },
		{ 124, "Payment processing services" },
		{ 125, "Shipping services" },
		{ 126, "Cleaning services" },
		{ 127, "Catering services" },
		{ 128, "Training services" },
		{ 129, "Legal services" },
		{ 130, "Accounting services" },
		{ 131, "Auditing services" },
		{ 132, "Insurance services" },
		{ 133, "Banking services" },
		{ 134, "Credit reporting services" },
		{ 135, "Utility services (electricity, water, waste disposal)" }
	};
		}

	}
}
