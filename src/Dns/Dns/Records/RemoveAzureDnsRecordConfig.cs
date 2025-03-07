﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.Dns
{
    using System;
    using System.Management.Automation;
    using Microsoft.Azure.Management.Dns.Models;
    using ProjectResources = Microsoft.Azure.Commands.Dns.Properties.Resources;

    /// <summary>
    /// Removes a record from a record set object.
    /// </summary>
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DnsRecordConfig"), OutputType(typeof(DnsRecordSet))]
    public class RemoveAzureDnsRecordConfig : DnsBaseCmdlet
    {
        private const string ParameterSetCaa = "Caa";

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The record set from which to remove the record.")]
        [ValidateNotNullOrEmpty]
        public DnsRecordSet RecordSet { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv4 address of the A record to remove.", ParameterSetName = "A")]
        [ValidateNotNullOrEmpty]
        public string Ipv4Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The IPv6 address of the AAAA record to remove.", ParameterSetName = "AAAA")]
        [ValidateNotNullOrEmpty]
        public string Ipv6Address { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The name server host of the NS record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "NS")]
        [ValidateNotNullOrEmpty]
        public string Nsdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The mail exchange host of the MX record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "MX")]
        [ValidateNotNullOrEmpty]
        public string Exchange { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference value of the MX record to remove.", ParameterSetName = "MX")]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The preference value of the NAPTR record to remove.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public ushort Preference { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host of the PTR record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "PTR")]
        [ValidateNotNullOrEmpty]
        public string Ptrdname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The text value of the TXT record to remove.", ParameterSetName = "TXT")]
        [ValidateNotNullOrEmpty]
        public string Value { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The priority value of the SRV record to remove.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Priority { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The target host of the SRV record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public string Target { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The port number of the SRV record to remove.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Port { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The weight value of the SRV record to remove.", ParameterSetName = "SRV")]
        [ValidateNotNullOrEmpty]
        public ushort Weight { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The canonical name of the CNAME record to remove. Must not be relative to the name of the zone. Must not have a terminating dot", ParameterSetName = "CNAME")]
        [ValidateNotNullOrEmpty]
        public string Cname { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The flags for the CAA record to remove. Must be a number between 0 and 255.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNullOrEmpty]
        public byte CaaFlags { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The tag field of the CAA record to remove.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNullOrEmpty]
        public string CaaTag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The value field for the CAA record to remove.", ParameterSetName = ParameterSetCaa)]
        [ValidateNotNull]
        [AllowEmptyString]
        [ValidateLength(DnsRecordBase.CaaRecordMinLength, DnsRecordBase.CaaRecordMaxLength)]
        public string CaaValue { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The key tag field of the DS record to remove.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public int KeyTag { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The algorithm field of the DS record to remove.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public int Algorithm { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The digest type field of the DS record to remove.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public int DigestType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The digest field of the DS record to remove.", ParameterSetName = "DS")]
        [ValidateNotNullOrEmpty]
        public string Digest { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The usage field of the TLSA record to remove.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public int Usage { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The selector field of the TLSA record to remove.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public int Selector { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The matching type field of the TLSA record to remove.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public int MatchingType { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The certificate association data field of the TLSA record to remove.", ParameterSetName = "TLSA")]
        [ValidateNotNullOrEmpty]
        public string CertificateAssociationData { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The order value of the NAPTR record to remove.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public ushort Order { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The flags value of the NAPTR record to remove.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public string Flags { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The service value of the NAPTR record to remove.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public string Services { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The regular expression value of the NAPTR record to remove.", ParameterSetName = "NAPTR")]
        [ValidateNotNull]
        [AllowEmptyString]
        public string Regexp { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The replacement value of the NAPTR record to remove.", ParameterSetName = "NAPTR")]
        [ValidateNotNullOrEmpty]
        public string Replacement { get; set; }

        public override void ExecuteCmdlet()
        {
            var result = this.RecordSet;
            if (!string.Equals(this.ParameterSetName, this.RecordSet.RecordType.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(string.Format(ProjectResources.Error_RemoveRecordTypeMismatch, this.ParameterSetName, this.RecordSet.RecordType));
            }

            int removedCount = 0;

            if (result.Records != null && result.Records.Count > 0)
            {
                switch (result.RecordType)
                {
                    case RecordType.A:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is ARecord
                                && ((ARecord)record).Ipv4Address == this.Ipv4Address);
                            break;
                        }

                    case RecordType.Aaaa:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is AaaaRecord
                                && ((AaaaRecord)record).Ipv6Address == this.Ipv6Address);
                            break;
                        }

                    case RecordType.MX:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is MxRecord
                                && string.Equals(((MxRecord)record).Exchange, this.Exchange, System.StringComparison.OrdinalIgnoreCase)
                                && ((MxRecord)record).Preference == this.Preference);
                            break;
                        }

                    case RecordType.Naptr:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is NaptrRecord
                                && ((NaptrRecord)record).Flags == this.Flags
                                && ((NaptrRecord)record).Order == this.Order
                                && string.Equals(((NaptrRecord)record).Regexp, this.Regexp, System.StringComparison.OrdinalIgnoreCase)
                                && string.Equals(((NaptrRecord)record).Replacement, this.Replacement, System.StringComparison.OrdinalIgnoreCase)
                                && string.Equals(((NaptrRecord)record).Services, this.Services, System.StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                    case RecordType.NS:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is NsRecord
                                && string.Equals(((NsRecord)record).Nsdname, this.Nsdname, System.StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                    case RecordType.SRV:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is SrvRecord
                                && ((SrvRecord)record).Priority == this.Priority
                                && ((SrvRecord)record).Port == this.Port
                                && string.Equals(((SrvRecord)record).Target, this.Target, System.StringComparison.OrdinalIgnoreCase)
                                && ((SrvRecord)record).Weight == this.Weight);
                            break;
                        }
                    case RecordType.TXT:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is TxtRecord
                                && ((TxtRecord)record).Value == this.Value);
                            break;
                        }
                    case RecordType.PTR:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is PtrRecord
                                && ((PtrRecord)record).Ptrdname == this.Ptrdname);
                            break;
                        }
                    case RecordType.Cname:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is CnameRecord
                                && string.Equals(((CnameRecord)record).Cname, this.Cname, System.StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                    case RecordType.CAA:
                        {
                            // CAAValue is considered binary. So, not doing a case-insensitive search
                            removedCount = result.Records.RemoveAll(record =>
                                record is CaaRecord
                                && string.Equals(((CaaRecord)record).Tag, this.CaaTag, System.StringComparison.OrdinalIgnoreCase)
                                && string.Equals(((CaaRecord)record).Value, this.CaaValue)
                                && ((CaaRecord)record).Flags == this.CaaFlags);
                            break;
                        }
                    case RecordType.DS:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                                record is DsRecord
                                && ((DsRecord)record).KeyTag == this.KeyTag
                                && ((DsRecord)record).Algorithm == this.Algorithm
                                && ((DsRecord)record).DigestType == this.DigestType
                                && string.Equals(((DsRecord)record).Digest, this.Digest, StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                    case RecordType.Tlsa:
                        {
                            removedCount = result.Records.RemoveAll(record =>
                            record is TlsaRecord
                            && ((TlsaRecord)record).Usage == this.Usage
                            && ((TlsaRecord)record).Selector == this.Selector
                            && ((TlsaRecord)record).MatchingType == this.MatchingType
                            && string.Equals(((TlsaRecord)record).CertificateAssociationData, this.CertificateAssociationData, StringComparison.OrdinalIgnoreCase));
                            break;
                        }
                }
            }

            WriteVerbose(ProjectResources.Success_RecordRemoved);

            WriteObject(result);
        }
    }
}
