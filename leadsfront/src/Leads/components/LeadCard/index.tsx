import { Container, Icon } from 'semantic-ui-react'
import { Lead } from '../../types/Lead'
import './style.css'
import { putAcceptLead, putDeclineLead } from '../../services/leadsService';

type LeadCardProps = {
    lead: Lead;
    isAcceptedList: boolean
    refetch: () => void
};

function LeadCard({ lead, isAcceptedList, refetch }: LeadCardProps) {
    const formatDate = (date: Date) => {
        return date.toLocaleString("en-US", {
            month: "long",
            day: "numeric",
            hour: "numeric",
            minute: "numeric",
            hour12: true,
        }).replace("at", " @");
    };

    const mutationAccept = putAcceptLead();
    const mutationDecline = putDeclineLead();

    const handleAccept = () => {
        mutationAccept.mutate(lead.id, {
            onSuccess: () => refetch()
        })
    }

    const handleDecline = () => {
        mutationDecline.mutate(lead.id, {
            onSuccess: () => refetch()
        })
    }

    return (
        <Container style={{ marginBottom: '2rem', padding: '2rem', background: '#fff' }}>
            <section className='profile'>
                <div className='iconName'>{lead.firstName.charAt(0).toLocaleUpperCase()}</div>
                <div className='profileInfo'>
                    <strong>{isAcceptedList ? lead.fullName : lead.firstName}</strong>
                    <span>{formatDate(new Date(lead.dateCreated))}</span>
                </div>
            </section>
            <hr />
            <section className='infos'>
                <Icon name='map marker alternate' size='small' />
                <span>{lead.suburb}</span>

                <Icon name='suitcase' size='small' style={{ marginLeft: '1rem' }} />
                <span>{lead.category}</span>

                <span style={{ marginLeft: '1rem' }}>Job ID: {lead.id}</span>
                {isAcceptedList && <span style={{ marginLeft: '1rem' }}><strong>${lead.price.toFixed(2)}</strong> Lead Invitation</span>}
            </section>
            <hr />
            <section className='description'>
                {isAcceptedList && <div className='contact'>
                    <Icon name='phone' />
                    <strong>{lead.phone}</strong>

                    <Icon name='mail' style={{ marginLeft: '2rem' }} />
                    <strong>{lead.email}</strong>
                </div>}
                <p>{lead.description}</p>
            </section>

            {!isAcceptedList &&
                <>
                    <hr />

                    <section className='action'>
                        <button onClick={handleAccept} style={{ background: 'orange', color: '#fff' }} >Accept</button>
                        <button onClick={handleDecline}>Decline</button>
                        <span><strong>${lead.price.toFixed(2)}</strong>Lead Invitation</span>
                    </section>
                </>}
        </Container>
    )
}

export default LeadCard
