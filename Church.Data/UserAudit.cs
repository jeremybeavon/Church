using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Church.Common;

namespace Church.Data
{
    /// <summary>
    /// Represents a user audit entry.
    /// </summary>
    [Table("user_audit")]
    public sealed class UserAudit : AbstractData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAudit"/> class.
        /// </summary>
        public UserAudit()
        {
            this.UserAuditId = Guid.NewGuid();
            this.Id = this.UserAuditId.ToString();
        }

        /// <summary>
        /// Gets or sets the user audit identifier.
        /// </summary>
        [Key]
        [Column("user_audit_id")]
        public Guid UserAuditId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        [Column("user_id")]
        public Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        [Column("audit_time")]
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the audit event.
        /// </summary>
        [Column("audit_event")]
        public AuditEvent Event { get; set; }
    }
}
